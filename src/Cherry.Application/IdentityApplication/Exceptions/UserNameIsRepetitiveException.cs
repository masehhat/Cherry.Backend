using Cherry.Application.Common.Exceptions;

namespace Cherry.Application.IdentityApplication.Exceptions
{
    public class UserNameIsRepetitiveException : AppBaseException
    {
        public UserNameIsRepetitiveException()
            : base("user name used by another user")
        {
        }
    }
}