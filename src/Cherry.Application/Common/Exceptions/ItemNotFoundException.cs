namespace Cherry.Application.Common.Exceptions
{
    public class ItemNotFoundException : AppBaseException
    {
        public ItemNotFoundException()
            : base("item not found")
        {
        }

        public ItemNotFoundException(string message)
            : base(message)
        {
        }
    }
}