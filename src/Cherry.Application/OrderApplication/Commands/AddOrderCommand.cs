using Cherry.Domain.Common;
using MediatR;
using System.Collections.Generic;

namespace Cherry.Application.OrderApplication.Commands
{
    public class AddOrderCommand : IRequest<int>
    {
        public string UserId { get; set; }
        public Dictionary<int, byte> FoodsAndCounts { get; set; }
        public Dictionary<int, Price> FoodsAndPrices { get; set; }
    }
}