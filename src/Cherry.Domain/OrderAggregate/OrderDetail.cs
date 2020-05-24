using Cherry.Domain.Common;

namespace Cherry.Domain.OrderAggregate
{
    public class OrderDetail
    {
        private OrderDetail()
        {
        }

        public OrderDetail(int foodId, byte count, Price unitPrice)
        {
            FoodId = foodId;
            Count = count;
            UnitPrice = unitPrice;
        }

        public int Id { get; set; }
        public int OrderId { get; set; }
        public int FoodId { get; }
        public byte Count { get; private set; }
        public Price UnitPrice { get; }
    }
}