namespace SecurityPractice.Tests.Customers
{
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using SecurityPractice.Domain.Customers.AddCustomer;
    using SecurityPractice.Tests.Common;

    [TestClass]
    public class AddCustomerHandlerTests : BaseIntegrationTest
    {
        [TestMethod]
        public async Task Handle_AddsCustomerToDatabase()
        {
            var request = CustomerHelper.AddCustomerRequest();

            var handler = new AddCustomerHandler(CustomerHelper.CustomerFactory(), CustomerHelper.CustomerRepository());

            await handler.Handle(request, CancellationToken.None);

            var customers = await CustomerHelper.AllCustomers();

            AssertionHelper.HasOnlyOne(customers);
            Assert.AreEqual(request.Email, customers.First().Email);
        }
    }
}
