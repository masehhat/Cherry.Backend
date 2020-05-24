using MediatR;

namespace Cherry.Application.OrderApplication.Commands
{
    public class CancelOrderCommand : IRequest
    {
        public string UserId { get; set; }
        public int OrderId { get; set; }
    }
}