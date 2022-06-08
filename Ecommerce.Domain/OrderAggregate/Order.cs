using System.ComponentModel.DataAnnotations;
using Ecommerce.Domain.Common;

namespace Ecommerce.Domain.OrderAggregate
{
    public class Order : BaseDomainEntity
    {
        public Order()
        {
        }

        public Order(IReadOnlyList<OrderItem> orderItems, string buyerEmail, 
            Address shipToAddress,
            DeliveryMethod deliveryMethod, double subtotal, string paymentIntentId)
        {
            BuyerEmail = buyerEmail;
            ShipToAddress = shipToAddress;
            DeliveryMethod = deliveryMethod;
            OrderItems = orderItems;
            Subtotal = subtotal;
            PaymentIntentId = paymentIntentId;
        }

        public string BuyerEmail { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.Now;
        public Address ShipToAddress { get; set; }
        public DeliveryMethod DeliveryMethod { get; set; }
        public IReadOnlyList<OrderItem> OrderItems {get; set;}
        public double Subtotal { get; set; } 
        public OrderStatus Status { get; set; } = OrderStatus.Pending;
        public string PaymentIntentId { get; set; }
        public double GetTotal()
        {
            return Subtotal + DeliveryMethod.Price;     
        }
    }
}