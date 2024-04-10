using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticApi.Persistance.Utilites.Helpers
{
    public static class StringFormat
    {
        public static string Capitalize(this string name)
        {
            name = name.Substring(0, 1).ToUpper() + name.Substring(1).ToLower();
            return name;
        }
    }
}
