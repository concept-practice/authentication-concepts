namespace SecurityPractice.Domain.Customers.Common
{
    using AddCustomer;
    using IsUsernameAvailable;
    using Models;

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
