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
using BLL;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using BLL.Services;
using BookShop.ViewModels;
using BookShop.Pages;
using WorkServices.Encryption;

namespace BookShop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ViewModel vm;
        public MainWindow()
        {
            InitializeComponent();
            vm = new ViewModel(this);
            this.DataContext = vm;
            //itemsListBox.ItemsSource = bookService.GetAll();
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void loginBtn_Click(object sender, RoutedEventArgs e)
        {
            var user = vm.userService.GetAll().Where(u => u.Login == loginTxtBox.Text && u.Password == EncryptionService.ComputeSha256Hash(passwordTxtBox.Password)).FirstOrDefault();
            if (user == null)
            {
                MessageBox.Show("Incorrect login or password");
                return;
            }
            vm.Logined_User = user;
            MessageBox.Show($"You logined as {vm.Logined_User.Login}");
            MainForm mf = new MainForm(vm,this);
            mf.Show();
            this.Hide();
        }

    }
}
