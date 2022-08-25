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
using Presentation.ViewModel;
using Microsoft.Win32;


namespace Presentation.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindowViewModel MainWindowModel { get; set; }

        public MainWindow()
        {
            InitializeComponent();

            MainWindowModel = new MainWindowViewModel();
            this.DataContext = MainWindowModel;
        }

        private void chooseDirButton_Click(object sender, RoutedEventArgs e)
        {
            //var openFileDialog = new OpenFileDialog();
            //openFileDialog.ShowDialog();
        }

    }
}
