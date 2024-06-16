using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticApi.Persistance.Utilites.Exceptions.Authentication
{
    public class UserNotFoundException : Exception
    {
        public UserNotFoundException(string message = "User not found.. ") : base(message)
        {
        }
    }
}
