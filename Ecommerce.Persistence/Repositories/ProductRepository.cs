using AutoMapper;
using Ecommerce.Application.Contracts.Persistence;
using Ecommerce.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Persistence.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
     
        private readonly StoreDbContext _context;

        public ProductRepository(StoreDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IReadOnlyList<ProductBrand>> GetBrandsAsync()
        {
            return await _context.ProductBrands.ToListAsync();
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await _context.Products.Include(p => p.ProductType)
                .Include(p => p.ProductBrand).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IReadOnlyList<Product>> ListAsync()
        {
            return await _context.Products.Include(p => p.ProductType)
                .Include(p => p.ProductBrand).ToListAsync();
        }

        public async Task<IReadOnlyList<ProductType>> GetTypesAsync()
        {
            return await _context.ProductTypes.ToListAsync();
        }
    }
}
