using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticApi.Persistance.Utilites.Exceptions.Authentication
{
    public class SamePasswordException : Exception
    {
        public SamePasswordException(string message = "The new password can't be the same as the old one.") : base(message)
        {
        }
    }
}
