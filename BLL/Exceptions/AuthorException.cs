using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Exceptions
{
    public class AuthorException : ApplicationException
    {
        public AuthorException(string message)
        : base(message)
        {

        }
    }
}
