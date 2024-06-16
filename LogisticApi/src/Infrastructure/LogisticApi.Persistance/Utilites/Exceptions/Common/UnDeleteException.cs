using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticApi.Persistance.Utilites.Exceptions.Common
{
    public class UnDeleteException : Exception
    {
        public UnDeleteException(string message = "This item can't delete") : base(message)
        {
        }
    }
}
