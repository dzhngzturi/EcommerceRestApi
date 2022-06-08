using Ecommerce.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.Contracts.Persistence
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        Task <Product> GetProductByIdAsync(int id);
        Task<IReadOnlyList<Product>> ListAsync();
        Task<IReadOnlyList<ProductBrand>> GetBrandsAsync();
        Task<IReadOnlyList<ProductType>> GetTypesAsync();
    }
}
