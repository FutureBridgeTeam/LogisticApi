using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticApi.Persistance.Utilites.Helpers
{
    public class EmailBodyCreator
    {
        public static string EmailBody(string resetLink)
        {
            return resetLink;
                /*$"Please reset your password using the following link: <a href='{resetLink}'>Reset Password</a>";*/
        }
    }
}
