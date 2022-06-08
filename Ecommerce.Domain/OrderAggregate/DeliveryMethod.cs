using Ecommerce.Domain.Common;

namespace Ecommerce.Domain.OrderAggregate
{
    public class DeliveryMethod : BaseDomainEntity
    {
        public string ShortName { get; set; }
        public string Description { get; set; }
        public string DeliveryTime { get; set; }
        public double Price { get; set; }
    }
}