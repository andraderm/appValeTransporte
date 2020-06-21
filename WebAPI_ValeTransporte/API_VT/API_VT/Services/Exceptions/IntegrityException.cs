using System;

namespace API_VT.Services.Exceptions
{
    public class IntegrityException : ApplicationException
    {
        public IntegrityException(string msg) : base(msg) { }
    }
}
