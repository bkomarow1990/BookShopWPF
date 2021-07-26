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
using WorkServices.Encryption;

namespace BookShop.Forms
{
    /// <summary>
    /// Interaction logic for Register.xaml
    /// </summary>
    public partial class Register : Window
    {
        ViewModel vm;
        public Register(ViewModel vm)
        {
            InitializeComponent();
            this.vm = vm;
            this.DataContext = vm;
        }

        private void registerBtn_Click(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrWhiteSpace(usernameTxtBox.Text))
            {
                MessageBox.Show("Incorrect login");
                return;
            }
            if (usernameTxtBox.Text.Length < 4)
            {
                MessageBox.Show("Login length must be more than 4 symbols");
                return;
            }
            if (vm.userService.GetAll().Any(u => (u.Login == usernameTxtBox.Text)))
            {
                MessageBox.Show("Username alredy used");
                return;
            }
            if (passwordTxtBox.Password.Length < 8)
            {
                MessageBox.Show("Password length must be more than 8 symbols");
                return;
            }
            vm.userService.Add(new BLL.DTOs.UserDTO { Login = usernameTxtBox.Text, Password = EncryptionService.ComputeSha256Hash(passwordTxtBox.Password) });
            MessageBox.Show("You was registred, happy reading :)");
            
            this.Close();
        }
    }
}
