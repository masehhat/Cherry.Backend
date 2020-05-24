using MediatR;

namespace Cherry.Application.OrderApplication.Notifications.CanceledNotification.Ping
{
    public class OrderCanceledNotification : INotification
    {
        public int OrderId { get; set; }
    }
}