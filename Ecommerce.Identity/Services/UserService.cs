using Ecommerce.Application.Contracts.Persistence.Services.Identity;
using Ecommerce.Application.Models.Identity;
using Ecommerce.Identity.Entity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Identity.Services
{
    public class UserService : IUserService
    {

        private readonly UserManager<AppUser> _userManager;

        public UserService(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<bool> CheckEmailExistsAsync(string email)
        {
          return await _userManager.FindByEmailAsync(email) != null;
        }

        public async Task<Employee> GetEmployee(string email)
        {
            var employee = await _userManager.FindByEmailAsync(email);
            return new Employee 
            {
                Id = employee.Id,
                Email = employee.Email,
                DisplayName = employee.DisplayName,
            };
        }

        public async Task<List<Employee>> GetEmployees()
        {
            var employees = await _userManager.GetUsersInRoleAsync("Employee");
            return employees.Select(q => new Employee
            {
                Id = q.Id,
                Email = q.Email,
                DisplayName = q.DisplayName,
            }).ToList();
        }
    }
}
