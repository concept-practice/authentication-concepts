namespace SecurityPractice.Domain.Customers.Common
{
    using SecurityPractice.Domain.Customers.AddCustomer;
    using SecurityPractice.Domain.Customers.IsUsernameAvailable;
    using SecurityPractice.Domain.Customers.Models;

    public class CustomerFactory : ICustomerFactory
    {
        public Customer Customer(AddCustomerRequest request)
        {
            return new Customer(request.Username, request.FirstName, request.LastName, request.Email);
        }

        public IsUsernameAvailableResponse IsUsernameAvailableResponse(bool result)
        {
            return new IsUsernameAvailableResponse(result);
        }
    }
}
