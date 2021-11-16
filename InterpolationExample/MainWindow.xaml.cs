using Microsoft.Win32;
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

namespace InterpolationExample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ViewModel model = new ViewModel();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void SelectButtonClick(object sender, RoutedEventArgs e)
        {
            var openFileDialog = new OpenFileDialog();
            openFileDialog.CheckFileExists = false;
            openFileDialog.Title = "Select or enter csv file name ...";
            openFileDialog.Filter = "Comma Seperated Value Files|*.csv";
            if (openFileDialog.ShowDialog().HasValue)
                model.File = openFileDialog.FileName;
        }

        private void SaveButtonClick(object sender, RoutedEventArgs e)
        {
            model.ExportFile();
        }
    }
}
