namespace SecurityPractice.Domain.Customers.Common
{
    using System.Threading.Tasks;
    using SecurityPractice.Domain.Customers.Models;

    public interface ICustomerRepository
    {
        Task AddEntity(Customer entity, string password);

        Task<bool> UsernameIsAvailable(string username);

        Task<Customer> GetByUsername(string username);
    }
}
