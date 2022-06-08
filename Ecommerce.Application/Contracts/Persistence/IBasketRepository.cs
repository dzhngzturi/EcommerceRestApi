using Ecommerce.Domain;

namespace Ecommerce.Application.Contracts.Persistence
{
    public interface IBasketRepository
    {
         Task<bool> DeleteBasketAsync(string basketId);
         Task<CustomerBasket> GetBasketAsync(string basketId);
         Task<CustomerBasket> UpdateBasketAsync(CustomerBasket basket);
         
    }
}