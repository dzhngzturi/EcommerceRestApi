using Ecommerce.Application.Constants;
using Ecommerce.Application.Contracts.Persistence;
using Ecommerce.Domain.Common;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly StoreDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private Hashtable _repositories;


        private IProductRepository _productRepository;
        private IProductTypeRepository _productTypeRepository;
        private IProductBrandRepository _productBrandRepository;
        public UnitOfWork(StoreDbContext context, IHttpContextAccessor httpContextAccessor )
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        public IProductRepository ProductRepository => _productRepository ??= new ProductRepository(_context);

        public IProductTypeRepository ProductTypeRepository => _productTypeRepository ??= new ProductTypeRepository(_context);

        public IProductBrandRepository ProductBrandRepository => _productBrandRepository ??= new ProductBrandRepository(_context);

        public async Task<int> Complete()
        {
            var username = _httpContextAccessor.HttpContext.User.FindFirst(CustomClaimTypes.Uid)?.Value;
            return await _context.SaveChangesAsync(username);
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public IGenericRepository<TEntity> Repository<TEntity>() where TEntity : BaseDomainEntity
        {
            if (_repositories == null) _repositories = new Hashtable();
            var type = typeof(TEntity).Name;

            if (!_repositories.ContainsKey(type))
            {
                var repositoryType = typeof(GenericRepository<>);
                var repositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(TEntity)),_context);
                _repositories.Add(type, repositoryInstance);
            }

            return (IGenericRepository<TEntity>) _repositories[type];
        }

        public async Task Save()
        {
            var username = _httpContextAccessor.HttpContext.User.FindFirst(CustomClaimTypes.Uid)?.Value;
            await _context.SaveChangesAsync(username);
        }
    }
}
