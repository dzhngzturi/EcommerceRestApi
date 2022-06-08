using AutoMapper;
using Ecommerce.Application.Contracts.Persistence;
using Ecommerce.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Persistence.Repositories
{
    public class ProductBrandRepository : GenericRepository<ProductBrand>, IProductBrandRepository
    {
        private readonly StoreDbContext _context;

        public ProductBrandRepository(StoreDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
