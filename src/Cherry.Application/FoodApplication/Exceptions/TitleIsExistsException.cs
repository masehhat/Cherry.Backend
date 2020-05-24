using Cherry.Application.Common.Exceptions;

namespace Cherry.Application.FoodApplication.Exceptions
{
    public class TitleIsExistsException : AppBaseException
    {
        public TitleIsExistsException()
            : base("title is exists, choose another title")
        {
        }
    }
}