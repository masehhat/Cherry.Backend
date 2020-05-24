using System;

namespace Cherry.Application.Common.Exceptions
{
    public class AppBaseException : Exception
    {
        public AppBaseException(string message)
            : base(message)
        {
        }
    }
}