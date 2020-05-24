using Cherry.Domain.Common;
using Cherry.Domain.OrderAggregate;
using Cherry.Infrastructure.Persistance;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Cherry.Application.OrderApplication.Commands
{
    public class AddOrderCommandHandler : IRequestHandler<AddOrderCommand, int>
    {
        private readonly CherryDbContext _context;

        public AddOrderCommandHandler(CherryDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(AddOrderCommand request, CancellationToken cancellationToken)
        {
            OrderDetail[] orderDetails = request.FoodsAndCounts.Select(x =>
            {
                Price price = request.FoodsAndPrices[x.Key];
                OrderDetail orderDetail = new OrderDetail(x.Key, x.Value, price);
                return orderDetail;
            }).ToArray();

            Order order = new Order(request.UserId, orderDetails);

            _context.Orders.Add(order);

            await _context.SaveChangesAsync();

            return order.Id;
        }
    }
}