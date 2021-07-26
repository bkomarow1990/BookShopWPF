using BLL.DTOs;
using BLL.Services;
using BookShop.Commands;
using BookShop.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace BookShop.ViewModels
{
    public class ViewModel
    {
        // Current properties
        public UserDTO Logined_User { get; set; }
        // Window
        Window window;
        // Database Services
        private readonly ICollection<UserDTO> contacts = new ObservableCollection<Contact>();
        public IAuthorService authorService = new AuthorService();
        public IBookService bookService = new BookService();
        public IUserService userService = new UserService();
        public ViewModel(Window window)
        {
            this.window = window;
            initCommands();
        }

        //State properties
        public bool IsExitedProgrammatically { get; set; } = false;
        // Login form commands 
        //DelegateCommands
        DelegateCommand closeWindowCommand;
        DelegateCommand minimizeWindowCommand;
        DelegateCommand registerWindowCommand;
        private void initCommands() {
            closeWindowCommand = new DelegateCommand(window.Close);
            minimizeWindowCommand = new DelegateCommand(()=>window.WindowState = WindowState.Minimized);
            registerWindowCommand = new DelegateCommand(()=> {
                Register registerForm = new Register(this);
                registerForm.ShowDialog();

            });
           
        }
        //Window Navigation Commands
        public ICommand CloseWindowCommand => closeWindowCommand;
        public ICommand MinimizeWindowCommand => minimizeWindowCommand;
        public ICommand RegisterWindowCommand => registerWindowCommand;
        
    }
}
