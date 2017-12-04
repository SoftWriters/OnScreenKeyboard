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

namespace OnScreenKeyboard
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ViewModel viewModel;
        public MainWindow()
        {
            InitializeComponent();
            viewModel = new ViewModel();
            this.DataContext = viewModel;
        }

        private void ProcessStringBtn_Click(object sender, RoutedEventArgs e)
        {
            viewModel.ProcessString(viewModel.LineToPrintTB);
        }

        private void UpdateKeyboardButton_Click(object sender, RoutedEventArgs e)
        {
            viewModel.UpdateKeyboard();
        }

        private void SelectFileBtn_Click(object sender, RoutedEventArgs e)
        {
            // Configure open file dialog box
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.FileName = "Document"; // Default file name
            dlg.DefaultExt = ".txt"; // Default file extension
            dlg.Filter = "Text documents (.txt)|*.txt"; // Filter files by extension

            // Show open file dialog box
            Nullable<bool> result = dlg.ShowDialog();

            // Process open file dialog box results
            if (result == true)
            {
                // Open document
                viewModel.InputFileName = dlg.FileName;
            }
        }

        private void ProcessFileBtn_Click(object sender, RoutedEventArgs e)
        {
            viewModel.ProcessFile();
        }
    }
}
