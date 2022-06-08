using Ecommerce.Application.Models.Identity;
using Ecommerce.Domain.OrderAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.Contracts.Persistence.Services.Identity
{
    public interface IUserService
    {
        
        Task<List<Employee>> GetEmployees();
        Task<Employee> GetEmployee(string email);
        Task<bool> CheckEmailExistsAsync(string email);

    }
}
