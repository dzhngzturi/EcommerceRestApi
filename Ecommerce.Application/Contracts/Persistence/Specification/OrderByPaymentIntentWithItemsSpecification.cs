using Ecommerce.Domain.OrderAggregate;

namespace Ecommerce.Application.Contracts.Persistence.Specification
{
    public class OrderByPaymentIntentWithItemsSpecification : BaseSpecification<Order>
    {
        public OrderByPaymentIntentWithItemsSpecification(string paymentIntentId) 
            : base(o => o.PaymentIntentId == paymentIntentId)
        {
        }
    }
}