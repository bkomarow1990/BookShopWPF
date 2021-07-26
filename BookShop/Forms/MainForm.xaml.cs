using BookShop.Pages;
using BookShop.ViewModels;
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
using System.Windows.Shapes;

namespace BookShop
{
    /// <summary>
    /// Interaction logic for MainForm.xaml
    /// </summary>
    public partial class MainForm : Window
    {
        MainWindow mw;
        ViewModel vm;
        public MainForm(ViewModel vm, MainWindow mw)
        {
            InitializeComponent();
            this.vm = vm;
            this.mw = mw;
            this.DataContext = vm;
            this.MainFrame.Content = new MainPage(vm);
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            if (!vm.IsExitedProgrammatically)
            {
                mw.Close();
            }
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            
            this.Close();
        }

        private void MinimizeButton_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void SignOutBtn_Click(object sender, RoutedEventArgs e)
        {
            vm.Logined_User = null;
            vm.IsExitedProgrammatically = true;
            this.Close();
            mw.Show();
            vm.IsExitedProgrammatically = false;
        }

        private void editPageBtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
