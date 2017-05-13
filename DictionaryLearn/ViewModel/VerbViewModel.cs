using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DictionaryLearn.Model;

namespace DictionaryLearn.ViewModel
{
    class VerbViewModel : ViewModelBase
    {
        private Verb verb;
        private string pastSimpleAnswer;
        private string participleIIAnswer;

        public VerbViewModel(Verb pVerb)
        {
            this.verb = pVerb;
        }

        public string PastSimpleAnswer
        {
            get
            {
                return pastSimpleAnswer;
            }
            set
            {
                pastSimpleAnswer = value;
                OnPropertyChanged("PastSimpleAnswer");
            }
        }
        public string ParticipleIIAnswer
        {
            get
            {
                return participleIIAnswer;
            }
            set
            {
                participleIIAnswer = value;
                OnPropertyChanged("ParticipleIIAnswer");
            }
        }
        public string Infinitive 
        {
            get
            {
                return verb.Infinitive;
            }
            set
            {
                verb.Infinitive = value;
                OnPropertyChanged("Infinitive");
            }
        }
        public string PastSimple
        {
            get
            {
                return verb.PastSimple;
            }
            set
            {
                verb.PastSimple = value;
                OnPropertyChanged("PastSimple");
            }
        }

        public string ParticipleII
        {
            get
            {
                return verb.ParticipleII;
            }
            set
            {
                verb.ParticipleII = value;
                OnPropertyChanged("ParticipleII");
            }
        }

    }
}
