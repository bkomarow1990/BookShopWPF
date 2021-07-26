using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class UserDTO
    {
        string login;
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
