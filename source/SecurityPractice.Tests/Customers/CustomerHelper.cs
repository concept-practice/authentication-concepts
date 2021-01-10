namespace SecurityPractice.Tests.Customers
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using SecurityPractice.Domain.Customers.AddCustomer;
    using SecurityPractice.Domain.Customers.Common;
    using SecurityPractice.Domain.Customers.Models;
    using SecurityPractice.Infrastructure.DataAccess.Customers;
    using SecurityPractice.Tests.Common;

    public static class CustomerHelper
    {
        public static ICustomerFactory CustomerFactory()
        {
            return new CustomerFactory();
        }

        public static ICustomerRepository CustomerRepository()
        {
            return new CustomerRepository(IntegrationHelper.UserManager());
        }

        public static async Task<IReadOnlyList<Customer>> AllCustomers()
        {
            return await IntegrationHelper.ApplicationContext().Users.ToListAsync();
        }

        public static AddCustomerRequest AddCustomerRequest()
        {
            return new AddCustomerRequest
            {
                FirstName = "John",
                LastName = "Doe",
                Email = "john@doe.com",
                Username = "johndoe",
                Password = "JohnDoe123!",
            };
        }
    }
}
