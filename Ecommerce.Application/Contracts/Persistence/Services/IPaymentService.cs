using Ecommerce.Domain;
using Ecommerce.Domain.OrderAggregate;

namespace Ecommerce.Application.Contracts.Persistence.Services
{
    public interface IPaymentService
    {
        Task<CustomerBasket> CreateOrUpdatePaymentIntent(string basketId);
       // Task<Order> UpdateOrderPaymentSucceeded(string paymentIntentId);
       // Task<Order> UpdateOrderPaymentFailed(string paymentIntentId);
    }
}