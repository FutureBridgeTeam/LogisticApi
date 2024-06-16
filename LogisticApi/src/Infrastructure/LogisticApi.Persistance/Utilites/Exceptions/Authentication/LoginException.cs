using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticApi.Persistance.Utilites.Exceptions.Authentication
{
    public class LoginException : Exception
    {
        public LoginException(string message = "Email , Username or Password is incorrect.. ") : base(message)
        {
        }
    }
}
