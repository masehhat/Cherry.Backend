namespace Cherry.Application.Common.Exceptions
{
    public class ModelValidationException : AppBaseException
    {
        public ModelValidationException(string message)
            : base(message)
        {
        }
    }
}