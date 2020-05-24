namespace Cherry.Domain.OrderAggregate
{
    public enum OrderStatus
    {
        Issued = 1,
        OnProcess = 2,
        OnTheWay = 3,
        Delivered = 4,
        Canceled = 5
    }
}