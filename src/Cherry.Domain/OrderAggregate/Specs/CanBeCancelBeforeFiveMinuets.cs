using Cherry.Domain.Common;
using Hulk.Extensions;
using System;
using System.Linq.Expressions;

namespace Cherry.Domain.OrderAggregate.Specs
{
    public class CanBeCancelBeforeFiveMinuets : Specification<Order>
    {
        public override Expression<Func<Order, bool>> ToExpression()
        {
            int fiveMinuetsAgo = DateTime.UtcNow.AddMinutes(-5).ToUnixTime();
            return order => order.CreatedAt > fiveMinuetsAgo;
        }
    }
}