using BookShop.Forms;
using BookShop.Pages;
using BookShop.ViewModels;
using MaterialDesignThemes.Wpf;
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
using System.Windows.Shapes;

namespace BookShop
{
    /// <summary>
    /// Interaction logic for MainForm.xaml
    /// </summary>
    public partial class MainForm : Window
    {
        MainWindow mw;
        private readonly PaletteHelper _paletteHelper = new PaletteHelper();
        ViewModel vm;
        public MainForm(ViewModel vm, MainWindow mw)
        {
            InitializeComponent();
            this.vm = vm;
            this.mw = mw;
            this.DataContext = vm;
            this.MainFrame.Content = new MainPage(vm);
            RegistryKey rk = Registry.CurrentUser.OpenSubKey("SOFTWARE\\BookShop");
            if (rk == null)
            {
                rk = Registry.CurrentUser.CreateSubKey("SOFTWARE\\BookShop");
            }
            RegistryKey rk2 = Registry.CurrentUser.OpenSubKey("SOFTWARE\\BookShop\\Theme");
            if (rk2 == null)
            {
                rk2 = Registry.CurrentUser.CreateSubKey("SOFTWARE\\BookShop\\Theme");
                rk2.SetValue("Theme","Light");
            }
            //RegistryKey currentUserKey = Registry.CurrentUser;
            //RegistryKey softwareKey = currentUserKey.OpenSubKey("SOFTWARE", true);
            //RegistryKey subHelloKey = softwareKey.CreateSubKey("BookShop");

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
            EditForm ef = new EditForm(vm);
            ef.ShowDialog();
        }

        private void themeCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            //RegistryKey currentUserKey = Registry.CurrentUser;
            RegistryKey rk = Registry.CurrentUser.OpenSubKey("SOFTWARE\\BookShop\\Theme",true);
            rk.SetValue("Theme", "Dark");
            SetTheme(false);

        }
        private void SetTheme(bool isDark) {
            ITheme theme = _paletteHelper.GetTheme();
            IBaseTheme baseTheme = isDark ? new MaterialDesignDarkTheme() : (IBaseTheme)new MaterialDesignLightTheme();
            theme.SetBaseTheme(baseTheme);
            _paletteHelper.SetTheme(theme);
        }
        private void themeCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            RegistryKey rk = Registry.CurrentUser.OpenSubKey("SOFTWARE\\BookShop\\Theme",true);
            rk.SetValue("Theme", "Light");
            SetTheme(true);
        }
    }
}
