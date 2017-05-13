using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using DictionaryLearn.Common;

namespace DictionaryLearn
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    //-------------------------------------------------------------------------------------------------------------------
    // class DictionaryView
    //-------------------------------------------------------------------------------------------------------------------
    public partial class DictionaryView : Window
    {
        public DictionaryView()
        //-------------------------------------------------------------------------------------------------------------------
        {
            InitializeComponent();
        }

        //-------------------------------------------------------------------------------------------------------------------
        private void Window_Loaded_1(object sender, RoutedEventArgs e)
        {
            viewVerbs.SelectedIndex = 0;
            SetFocus();
            ISetFocusQueriable viewModel = DataContext as ISetFocusQueriable;
            if (viewModel != null)
            {
                viewModel.QuerySetFocus += SetFocus;
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        private void SetFocus()
        {
            Keyboard.Focus(txtPastSimpleAnswer);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
        }
        //-------------------------------------------------------------------------------------------------------------------
    }
    //-------------------------------------------------------------------------------------------------------------------
}
