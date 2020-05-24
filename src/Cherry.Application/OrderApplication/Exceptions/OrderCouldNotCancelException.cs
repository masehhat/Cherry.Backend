using Cherry.Application.Common.Exceptions;

namespace Cherry.Application.OrderApplication.Exceptions
{
    public class OrderCouldNotCancelException : AppBaseException
    {
        public OrderCouldNotCancelException()
            : base("order could not cancel")
        {
        }
    }
}