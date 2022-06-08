using Ecommerce.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.Contracts.Persistence
{
    public interface IUnitOfWork : IDisposable
    {
        IProductRepository ProductRepository { get; }
        IProductTypeRepository ProductTypeRepository { get; }
        IProductBrandRepository ProductBrandRepository { get; }
        IGenericRepository<TEntity> Repository<TEntity>() where TEntity : BaseDomainEntity;
        Task<int> Complete();
        Task Save();
    }
}
