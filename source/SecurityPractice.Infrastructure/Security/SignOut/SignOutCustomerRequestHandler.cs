namespace SecurityPractice.Infrastructure.Security.SignOut
{
    using System.Threading;
    using System.Threading.Tasks;
    using Domain.Customers.Models;
    using MediatR;
    using Microsoft.AspNetCore.Identity;

    public class SignOutCustomerRequestHandler : IRequestHandler<SignOutCustomerRequest>
    {
        private readonly SignInManager<Customer> _signInManager;

        public SignOutCustomerRequestHandler(SignInManager<Customer> signInManager)
        {
            _signInManager = signInManager;
        }

        public async Task<Unit> Handle(SignOutCustomerRequest request, CancellationToken cancellationToken)
        {
            await _signInManager.SignOutAsync();

            return Unit.Value;
        }
    }
}
