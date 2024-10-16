﻿using LogisticApi.Application.Utilites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticApi.Persistance.Utilites.Exceptions.Common
{
    public class AlreadyExistException : Exception, IBaseException
    {
        public AlreadyExistException(string message = "This item already exist") : base(message)
        {
        }
    }
}
