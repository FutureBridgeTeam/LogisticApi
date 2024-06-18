﻿using LogisticApi.Application.Utilites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticApi.Persistance.Utilites.Exceptions.Common
{
    public class BadRequestException : Exception, IBaseException
    {
        public BadRequestException(string message = "Bad Request.. ") : base(message)
        {
        }
    }
}
