using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using DictionaryLearn.ViewModel;

namespace DictionaryLearn
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void OnStartup(object sender, StartupEventArgs e)
        {
            DictionaryView view = new DictionaryView(); // создали View
            DictionaryViewModel viewModel = new DictionaryViewModel(); // Создали ViewModel
            viewModel.Create();
            view.DataContext = viewModel; // положили ViewModel во View в качестве DataContext
            viewModel.SelectedIndex = 0;
            view.Show();
        }
    }
}
