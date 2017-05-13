using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using DictionaryLearn.Model;
using System.Windows;
using System.Windows.Input;
using DictionaryLearn.Common;

namespace DictionaryLearn.ViewModel
{
    public enum AnswrerState {Answer, Correction};
    //-------------------------------------------------------------------------------------------------------------------
    // class DictionaryViewModel
    //-------------------------------------------------------------------------------------------------------------------
    class DictionaryViewModel : ViewModelBase, ISetFocusQueriable
    {
        public ObservableCollection<VerbViewModel> VerbList { get; set; }
        public ObservableCollection<VerbViewModel> IncorrectVerb { get; set; }
        public ObservableCollection<VerbViewModel> CorrectVerb { get; set; }
        private int errorLevel = 0;
        private int passNumber = 0;
        private int doneNumber = 0;
        private int errorLevelCurrent = 0;
        private int passNumberCurrent = 0;
        private int doneNumberCurrent = 0;
        private int attemptNumber = 1;
        private int remainNumber = 0;
        private Visibility verbFormsVisible = Visibility.Hidden;
        private AnswrerState state = AnswrerState.Answer;
        private object selectedItem;
        private int selectedIndex;
        private bool isFirstFieldFocused;
        //------------------------------------------------------------------------------------------------------------------
        public event Action QuerySetFocus;
        //-------------------------------------------------------------------------------------------------------------------
        public int ErrorLevel
        {
            get
            {
                return errorLevel;
            }
            set
            {
                errorLevel = value;
                OnPropertyChanged("ErrorLevel");
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        public int PassNumber
        {
            get
            {
                return passNumber;
            }
            set
            {
                passNumber = value;
                OnPropertyChanged("PassNumber");
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        public int DoneNumber
        {
            get
            {
                return doneNumber;
            }
            set
            {
                doneNumber = value;
                OnPropertyChanged("DoneNumber");
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        public int ErrorLevelCurrent
        {
            get
            {
                return errorLevelCurrent;
            }
            set
            {
                errorLevelCurrent = value;
                OnPropertyChanged("ErrorLevelCurrent");
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        public int PassNumberCurrent
        {
            get
            {
                return passNumberCurrent;
            }
            set
            {
                passNumberCurrent = value;
                OnPropertyChanged("PassNumberCurrent");
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        public int DoneNumberCurrent
        {
            get
            {
                return doneNumberCurrent;
            }
            set
            {
                doneNumberCurrent = value;
                OnPropertyChanged("DoneNumberCurrent");
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        public Visibility VerbFormsVisible
        {
            get 
            {
                return verbFormsVisible;
            }
            set
            {
                verbFormsVisible = value;
                OnPropertyChanged("VerbFormsVisible");
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        public int AttemptNumber
        {
            get
            {
                return attemptNumber;
            }
            set
            {
                attemptNumber = value;
                OnPropertyChanged("AttemptNumber");
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        public int RemainNumber
        {
            get
            {
                return remainNumber;
            }
            set
            {
                remainNumber = value;
                OnPropertyChanged("RemainNumber");
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        public object SelectedItem
        {
            get
            {
                return selectedItem;
            }
            set
            {
                selectedItem = value;
                OnPropertyChanged("SelectedItem");
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        public int SelectedIndex
        {
            get
            {
                return selectedIndex;
            }
            set
            {
                selectedIndex = value;
                OnPropertyChanged("SelectedIndex");
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        public AnswrerState State
        {
            get
            {
                return state;
            }
            set
            {
                state = value;
                OnPropertyChanged("State");
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        public bool IsFirstFieldFocused
        {
            get
            {
                return isFirstFieldFocused;
            }
            set
            {
                isFirstFieldFocused = value;
                OnPropertyChanged("IsFirstFieldFocused");
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        public DictionaryViewModel()
        {
        }
        //-------------------------------------------------------------------------------------------------------------------
        public void Create()
        {
            List<Verb> verbs = GetVerbs();
            //List<string> SS = verbs.Select(v => v.PastSimple).ToList();
            //string s = string.Join("'," + Environment.NewLine + "'", SS);
            VerbList = new ObservableCollection<VerbViewModel>(verbs.Select(v => new VerbViewModel(v)));
            IncorrectVerb = new ObservableCollection<VerbViewModel>();
            CorrectVerb = new ObservableCollection<VerbViewModel>();
            RemainNumber = VerbList.Count;
            SelectedIndex = 0;
        }
        //-------------------------------------------------------------------------------------------------------------------
        private List<Verb> GetVerbs()
        {
            //List<Verb> verbs = new List<Verb>
            //{
            //    new Verb(){Infinitive = "beat", PastSimple = "beat", ParticipleII = "beaten"},
            //    new Verb(){Infinitive = "become", PastSimple = "became", ParticipleII = "become"},
            //    new Verb(){Infinitive = "begin", PastSimple = "began", ParticipleII = "begun"}
            //};
            //return verbs;

            List<Verb> r = Verb.CreateFromHTML();

            Verb.SaveDictionary(r);

            return r;
        }
        //-------------------------------------------------------------------------------------------------------------------
        private DelegateCommand acceptCommand;
        //-------------------------------------------------------------------------------------------------------------------
        public ICommand AcceptCommand
        {
            get
            {
                if (acceptCommand == null)
                {
                    acceptCommand = new DelegateCommand(AcceptAction, CanAcceptAction);
                }
                return acceptCommand;
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        private void AcceptAction()
        {
            try
            {
                VerbViewModel lCurrentVerb = selectedItem as VerbViewModel;
                if (lCurrentVerb != null && !string.IsNullOrEmpty(lCurrentVerb.ParticipleIIAnswer) && !string.IsNullOrEmpty(lCurrentVerb.PastSimpleAnswer))
                {
                    if (lCurrentVerb != null)
                    {
                        int lCurrentErrorLevel = 0;
                        lCurrentErrorLevel += lCurrentVerb.ParticipleII.Trim().ToLower() == lCurrentVerb.ParticipleIIAnswer.Trim().ToLower() ? 0 : 1;
                        lCurrentErrorLevel += lCurrentVerb.PastSimple.Trim().ToLower() == lCurrentVerb.PastSimpleAnswer.Trim().ToLower() ? 0 : 1;
                        if (lCurrentErrorLevel == 0)
                        {
                            GotoNextVerb();
                        }
                        else
                        {
                            if (State == AnswrerState.Answer)
                            {
                                State = AnswrerState.Correction;
                                VerbFormsVisible = Visibility.Visible;
                                ErrorLevel += (lCurrentErrorLevel + 1) << (AttemptNumber - 1);
                            }
                            else
                            {
                            }
                        }
                    }
                    else if (VerbList.Count > 0)
                    {
                        SelectedIndex = 0;
                    }
                }
                OnQuerySetFocus();
            }
            catch (Exception e)
            {
                Console.Write(e.ToString());
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        private void GotoNextVerb()
        {
            if (State == AnswrerState.Answer)
            {
                PassNumber++;
                CorrectVerb.Add(SelectedItem as VerbViewModel);
            }
            else
            {
                IncorrectVerb.Add(SelectedItem as VerbViewModel);
            }
            VerbList.Remove(SelectedItem as VerbViewModel);
            RemainNumber--;
            DoneNumber++;
            State = AnswrerState.Answer;
            VerbFormsVisible = Visibility.Hidden;
            SelectedIndex = 0;
            IsFirstFieldFocused = true;
        }
        //-------------------------------------------------------------------------------------------------------------------
        private bool CanAcceptAction()
        {
            return true;
        }
        //-------------------------------------------------------------------------------------------------------------------
        private DelegateCommand nextAttemptCommand;
        //-------------------------------------------------------------------------------------------------------------------
        public ICommand NextAttemptCommand
        {
            get
            {
                if (nextAttemptCommand == null)
                {
                    nextAttemptCommand = new DelegateCommand(NextAttemptAction, CanNextAttemptAction);
                }
                return nextAttemptCommand;
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        private void NextAttemptAction()
        {
            ErrorLevelCurrent = 0;
            PassNumberCurrent = 0;
            DoneNumberCurrent = 0;
            AttemptNumber++;
            foreach (var v in IncorrectVerb)
            {
                v.PastSimpleAnswer = "";
                v.ParticipleIIAnswer = "";
                VerbList.Add(v);
            }

            RemainNumber = VerbList.Count;
            IncorrectVerb.Clear();
            OnQuerySetFocus();

        }
        //-------------------------------------------------------------------------------------------------------------------
        private bool CanNextAttemptAction()
        {
            return VerbList.Count == 0 && IncorrectVerb.Count > 0;
        }
        //-------------------------------------------------------------------------------------------------------------------
        private DelegateCommand newSeansCommand;
        //-------------------------------------------------------------------------------------------------------------------
        public ICommand NewSeansCommand
        {
            get
            {
                if (newSeansCommand == null)
                {
                    newSeansCommand = new DelegateCommand(NewSeansAction, CanNewSeansAction);
                }
                return newSeansCommand;
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        private void NewSeansAction()
        {
            ErrorLevelCurrent = 0;
            PassNumberCurrent = 0;
            DoneNumberCurrent = 0;
            ErrorLevel = 0;
            PassNumber = 0;
            DoneNumber = 0;
            AttemptNumber = 0;
            foreach (var v in CorrectVerb)
            {
                v.PastSimpleAnswer = "";
                v.ParticipleIIAnswer = "";
                VerbList.Add(v);
            }

            RemainNumber = VerbList.Count;
            IncorrectVerb.Clear();
            CorrectVerb.Clear();

        }
        //-------------------------------------------------------------------------------------------------------------------
        private bool CanNewSeansAction()
        {
            return CorrectVerb.Count > 0 && IncorrectVerb.Count == 0 && VerbList.Count == 0;
        }
        //-------------------------------------------------------------------------------------------------------------------
        public void OnQuerySetFocus()
        {
            Action handle = QuerySetFocus;
            if (handle != null)
                handle();
        }
        //-------------------------------------------------------------------------------------------------------------------
        private void Settings_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            Create();
        }
        //-------------------------------------------------------------------------------------------------------------------
    }
    //-------------------------------------------------------------------------------------------------------------------
}
