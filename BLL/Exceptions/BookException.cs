using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Exceptions
{
    public class BookException : ApplicationException
    {
        public BookException(string message)
        :base(message){

        }
    }
}
