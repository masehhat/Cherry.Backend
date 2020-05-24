using Cherry.Domain.OrderAggregate.Specs;
using Hulk.Extensions;
using System;
using System.Collections.Generic;

namespace Cherry.Domain.OrderAggregate
{
    public class Order
    {
        private Order()
        {
        }

        public Order(string userId, OrderDetail[] details)
        {
            CreatedAt = DateTime.UtcNow.ToUnixTime();
            Status = OrderStatus.Issued;
            UserId = userId;
            Details = details;
        }

        public int Id { get; set; }
        public int CreatedAt { get; }
        public string UserId { get; }
        public OrderStatus Status { get; private set; }
        public ICollection<OrderDetail> Details { get; private set; }

        public bool IsCancelable
        {
            get
            {
                CanBeCancelBeforeFiveMinuets spec1 = new CanBeCancelBeforeFiveMinuets();
                CanBeCancelBeforeProcessing spec2 = new CanBeCancelBeforeProcessing();

                return spec1.And(spec2).IsSatisfiedBy(this);
            }
        }

        public void Cancel()
        {
            CanBeCancelBeforeFiveMinuets spec1 = new CanBeCancelBeforeFiveMinuets();
            CanBeCancelBeforeProcessing spec2 = new CanBeCancelBeforeProcessing();

            if (spec1.And(spec2).IsSatisfiedBy(this))
                Status = OrderStatus.Canceled;
        }
    }
}