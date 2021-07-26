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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BookShop.Pages
{
    /// <summary>
    /// Interaction logic for MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        ViewModel vm;
        public MainPage(ViewModel vm)
        {
            InitializeComponent();
            this.vm = vm;
            this.DataContext = vm;
            this.booksListBox.ItemsSource = vm.bookService.GetAll().ToList();
        }
    }
}
