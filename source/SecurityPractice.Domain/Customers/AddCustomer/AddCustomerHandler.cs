namespace SecurityPractice.Domain.Customers.AddCustomer
{
    using System.Threading;
    using System.Threading.Tasks;
    using Common;
    using MediatR;

    public class AddCustomerHandler : IRequestHandler<AddCustomerRequest>
    {
        private readonly ICustomerFactory _securityFactory;
        private readonly ICustomerRepository _customerRepository;

        public AddCustomerHandler(ICustomerFactory securityFactory, ICustomerRepository customerRepository)
        {
            _securityFactory = securityFactory;
            _customerRepository = customerRepository;
        }

        public async Task<Unit> Handle(AddCustomerRequest request, CancellationToken cancellationToken)
        {
            var customer = _securityFactory.Customer(request);

            await _customerRepository.AddEntity(customer, request.Password);

            return Unit.Value;
        }
    }
}
