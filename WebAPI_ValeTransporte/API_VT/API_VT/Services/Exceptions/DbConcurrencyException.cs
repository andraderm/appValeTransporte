﻿using System;

namespace API_VT.Services.Exceptions
{
    public class DbConcurrencyException : ApplicationException
    {
        public DbConcurrencyException(string msg) : base(msg) { }
    }
}
