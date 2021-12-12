namespace SecurityPractice.Infrastructure.Security.SignIn
{
    using System.Threading;
    using System.Threading.Tasks;
    using Domain.Customers.Models;
    using MediatR;
    using Microsoft.AspNetCore.Identity;

    public class SignInCustomerRequestHandler : IRequestHandler<SignInCustomerRequest>
    {
        private readonly SignInManager<Customer> _signInManager;

        public SignInCustomerRequestHandler(SignInManager<Customer> signInManager)
        {
            _signInManager = signInManager;
        }

        public async Task<Unit> Handle(SignInCustomerRequest request, CancellationToken cancellationToken)
        {
            await _signInManager.PasswordSignInAsync(request.Username, request.Password, true, false);

            return Unit.Value;
        }
    }
}
