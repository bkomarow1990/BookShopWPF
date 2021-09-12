using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using BLL.DTOs;
using BLL.Exceptions;
using BookShop.ViewModels;
using NumericUpDownLib.Base;
namespace BookShop.Forms
{
    /// <summary>
    /// Interaction logic for EditForm.xaml
    /// </summary>
    public partial class EditForm : Window
    {
        ViewModel vm;
        public EditForm(ViewModel vm)
        {
            InitializeComponent();
            this.vm = vm;
            InitControls();

        }
        private void InitControls() {
            this.genreComboBox.ItemsSource = vm.genreService.GetAll();
        }
        private void surnameTxtBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void addBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                BookDTO book = new BookDTO();
                if (String.IsNullOrWhiteSpace(nameTxtBox.Text))
                {
                    throw new BookException("Incorrect name of book");
                }
                if (vm.bookService.GetAll().Any(el=> el.Name == nameTxtBox.Text))
                {
                    throw new BookException("Book is alredy exists");
                }
                book.Name = nameTxtBox.Text;
                book.Count_Pages = Int32.Parse(countPagesTxtBox.Text);
                if (!vm.bookService.GetAll().Any(el=> el.Author.Name == authorNameTxtBox.Text && el.Author.Surname == authorSurnameTxtBox.Text))
                {
                    var createNewAuthor = MessageBox.Show("Author isn`t exist, create new?","Create new author", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (createNewAuthor == MessageBoxResult.No)
                    {
                        return;
                    }
                    vm.authorService.Add(new AuthorDTO { Name = authorNameTxtBox.Text, Surname = authorSurnameTxtBox.Text});
                    if (genreComboBox.SelectedItem == null)
                    {
                        throw new GenreException("Select genre of book");
                    }
                    book.Genre = (genreComboBox.SelectedItem as GenreDTO);
                    if (String.IsNullOrWhiteSpace(departmentNameTxtBox.Text) || !vm.departmentService.GetAll().Any(el=> el.Name == departmentNameTxtBox.Text))
                    {
                        var createDepartment = MessageBox.Show("Department isn`t exist, create new?", "Create new department", MessageBoxButton.YesNo, MessageBoxImage.Question);
                        if (createNewAuthor == MessageBoxResult.Yes)
                        {
                            DepartmentDTO department = new DepartmentDTO { Name = departmentNameTxtBox.Text };
                            vm.departmentService.Add(department);
                            book.Department = department;
                        }
                    }
                    book.PublishYear = Int32.Parse(publishingYearTxtBox.Text);
                    book.Price = Int32.Parse(priceTxtBox.Text);
                    book.Public_Price = Int32.Parse(publicPriceTxtBox.Text);
                    if (vm.bookService.GetAll().Any(el => el.Name == parentBookNameTxtBox.Text))
                    {
                        book.Parent_Book = vm.bookService.GetAll().Where(el => el.Name == parentBookNameTxtBox.Text).First();
                    }
                    vm.bookService.Add(book);
                    MessageBox.Show("Book was added");
                }

            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
