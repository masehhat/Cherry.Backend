using Cherry.Application.Common.Exceptions;

namespace Cherry.Application.OrderApplication.Exceptions
{
    public class SelectedFoodIsWrongException : AppBaseException
    {
        public SelectedFoodIsWrongException()
            : base("selected food id is wrong")
        {
        }
    }
}