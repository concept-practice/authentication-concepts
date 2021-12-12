namespace SecurityPractice.Infrastructure.Security.SignIn
{
    using System;
    using System.Collections.Generic;
    using System.Security.Claims;
    using System.Threading;
    using System.Threading.Tasks;
    using Domain.Customers.Models;
    using MediatR;
    using Microsoft.AspNetCore.Identity;
    using Tokens;

    public class SignInCustomerRequestHandler : IRequestHandler<SignInCustomerRequest, string>
    {
        private readonly SignInManager<Customer> _signInManager;
        private readonly ITokenService _tokenService;

        public SignInCustomerRequestHandler(SignInManager<Customer> signInManager, ITokenService tokenService)
        {
            _signInManager = signInManager;
            _tokenService = tokenService;
        }

        public async Task<string> Handle(SignInCustomerRequest request, CancellationToken cancellationToken)
        {
            var result = await _signInManager.PasswordSignInAsync(request.Username, request.Password, true, false);

            var claims = new List<Claim>
            {
                new Claim("Id", Guid.NewGuid().ToString()),
                // new Claim("Audience", TokenConstants.Audience),
                // new Claim("Issuer", TokenConstants.Issuer),
            };

            var meh = _tokenService.GenerateToken(claims);

            return meh;
        }
    }
}
