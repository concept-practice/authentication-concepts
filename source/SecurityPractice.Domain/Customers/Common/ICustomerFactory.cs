namespace SecurityPractice.Domain.Customers.Common
{
    using AddCustomer;
    using IsUsernameAvailable;
    using Models;

    public interface ICustomerFactory
    {
        public Customer Customer(AddCustomerRequest request);

        public IsUsernameAvailableResponse IsUsernameAvailableResponse(bool result);
    }
}
