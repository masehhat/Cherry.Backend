using Cherry.Application.OrderApplication.Notifications.CanceledNotification.Ping;
using Cherry.Infrastructure.Services;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Cherry.Application.OrderApplication.Notifications.CanceledNotification.Pongs
{
    public class OrderCanceledSmsNotification : INotificationHandler<OrderCanceledNotification>
    {
        private readonly ISendSmsService _sendSmsService;

        public OrderCanceledSmsNotification(ISendSmsService sendSmsService)
        {
            _sendSmsService = sendSmsService;
        }

        public async Task Handle(OrderCanceledNotification notification, CancellationToken cancellationToken)
        {
            await _sendSmsService.SendSms();
        }
    }
}