using Ecommerce.Application.Contracts.Persistence.Specification;
using Ecommerce.Application.Profiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.Contracts.Persistence
{
    public interface IGenericRepository <T> where T : class
    {
        Task<T> GetByIdAsync(int id);
        Task<IReadOnlyList<T>> ListAllAsync();
        Task<T> GetEntityWithSpec(ISpecification<T> spec);
        Task<IReadOnlyList<T>> ListAsyncWithSpec(ISpecification<T> spec);
        Task<int> CountAsync(ISpecification<T> spec);
        Task<bool> Exist(int id);
        Task<T> Add(T entity);
        Task Update(T entity);
        Task Delete(T entity);

    }
}
