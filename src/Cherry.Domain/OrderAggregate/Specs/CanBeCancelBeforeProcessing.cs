using Cherry.Domain.Common;
using System;
using System.Linq.Expressions;

namespace Cherry.Domain.OrderAggregate.Specs
{
    public class CanBeCancelBeforeProcessing : Specification<Order>
    {
        public override Expression<Func<Order, bool>> ToExpression()
            => order => order.Status == OrderStatus.Issued;
    }
}