using System.Security.Claims;

namespace SecurityPractice.Infrastructure.DataAccess.Customers
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Identity;
    using SecurityPractice.Domain.Customers.Common;
    using SecurityPractice.Domain.Customers.Models;

    public class CustomerRepository : ICustomerRepository
    {
        private readonly UserManager<Customer> _userManager;

        public CustomerRepository(UserManager<Customer> userManager)
        {
            _userManager = userManager;
        }

        public async Task AddEntity(Customer entity, string password)
        {
            await _userManager.CreateAsync(entity, password);

            await _userManager.AddClaimAsync(entity, new Claim("Customer", "true"));
        }

        public async Task<bool> UsernameIsAvailable(string username)
        {
            return await GetByUsername(username) == null;
        }

        public async Task<Customer> GetByUsername(string username)
        {
            return await _userManager.FindByNameAsync(username);
        }
    }
}
