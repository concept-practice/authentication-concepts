namespace SecurityPractice.Domain.Customers.Common
{
    using SecurityPractice.Domain.Customers.AddCustomer;
    using SecurityPractice.Domain.Customers.IsUsernameAvailable;
    using SecurityPractice.Domain.Customers.Models;

    public interface ICustomerFactory
    {
        public Customer Customer(AddCustomerRequest request);

        public IsUsernameAvailableResponse IsUsernameAvailableResponse(bool result);
    }
}
