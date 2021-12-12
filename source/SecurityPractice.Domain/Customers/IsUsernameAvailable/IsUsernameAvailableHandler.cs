namespace SecurityPractice.Domain.Customers.IsUsernameAvailable
{
    using System.Threading;
    using System.Threading.Tasks;
    using Common;
    using MediatR;

    public class IsUsernameAvailableHandler : IRequestHandler<IsUsernameAvailableRequest, IsUsernameAvailableResponse>
    {
        private readonly ICustomerFactory _customerFactory;
        private readonly ICustomerRepository _customerRepository;

        public IsUsernameAvailableHandler(ICustomerFactory customerFactory, ICustomerRepository customerRepository)
        {
            _customerFactory = customerFactory;
            _customerRepository = customerRepository;
        }

        public async Task<IsUsernameAvailableResponse> Handle(IsUsernameAvailableRequest request, CancellationToken cancellationToken)
        {
            var isUsernameTaken = await _customerRepository.UsernameIsAvailable(request.Username);

            return _customerFactory.IsUsernameAvailableResponse(isUsernameTaken);
        }
    }
}
