using BLL.DTOs;
using BLL.Services;
using BookShop.Commands;
using BookShop.Forms;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace BookShop.ViewModels
{
    public class ViewModel : INotifyPropertyChanged
    {
        // Current properties
        public UserDTO Logined_User { get; set; }
        // Window
        Window window;
        // Database Services
        ICollection<BookDTO> books;
        public ICollection<BookDTO> Books { get => books; set {
                this.books = value; OnPropertyChanged();
            }  }
        public IAuthorService authorService = new AuthorService();
        public IBookService bookService = new BookService();
        public IUserService userService = new UserService();
        public IGenreService genreService = new GenreService();
        public IDepartmentService departmentService = new DepartmentService();
        public ViewModel(Window window)
        {
            this.window = window;
            Books = new ObservableCollection<BookDTO>(bookService.GetAll());
            bookService.Add(new BookDTO { Name = "Tets", AuthorId = 1, Count_Pages = 22, GenreId = 1, Price = 222, Public_Price = 228, PublishYear = 2019 });
            Books = new ObservableCollection<BookDTO>(bookService.GetAll());
            //bookService.Save();
            //var test = bookService.GetAll().ToList()[0];
            //test.Count_Pages++;
            //bookService.Update(test);
            bookService.Save();
            initCommands();
        }

        //State properties
        public bool IsExitedProgrammatically { get; set; } = false;
        // Login form commands 
        //DelegateCommands
        DelegateCommand closeWindowCommand;
        DelegateCommand minimizeWindowCommand;
        DelegateCommand registerWindowCommand;

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
        private void initCommands() {
            closeWindowCommand = new DelegateCommand(window.Close);
            minimizeWindowCommand = new DelegateCommand(()=>window.WindowState = WindowState.Minimized);
            registerWindowCommand = new DelegateCommand(()=> {
                Register registerForm = new Register(this);
                registerForm.Show();

            });
           
        }
        //Window Navigation Commands
        public ICommand CloseWindowCommand => closeWindowCommand;
        public ICommand MinimizeWindowCommand => minimizeWindowCommand;
        public ICommand RegisterWindowCommand => registerWindowCommand;
        
    }
}
