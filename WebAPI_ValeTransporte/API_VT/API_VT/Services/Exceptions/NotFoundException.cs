using System;

namespace API_VT.Services.Exceptions
{
    public class NotFoundException : ApplicationException
    {
        public NotFoundException(string msg) : base(msg) { }
    }
}
