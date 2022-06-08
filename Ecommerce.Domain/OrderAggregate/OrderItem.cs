using Ecommerce.Domain.Common;

namespace Ecommerce.Domain.OrderAggregate
{
    public class OrderItem : BaseDomainEntity
    {
        public OrderItem()
        {
        }

        public OrderItem(ProductItemOrdered itemOrdered, double price, int quantity)
        {
            ItemOrdered = itemOrdered;
            Price = price;
            Quantity = quantity;
        }

        public ProductItemOrdered ItemOrdered { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
    }
}