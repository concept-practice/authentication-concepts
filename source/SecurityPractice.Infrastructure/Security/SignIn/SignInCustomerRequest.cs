namespace SecurityPractice.Infrastructure.Security.SignIn
{
    using MediatR;

    public class SignInCustomerRequest : IRequest
    {
        public string Username { get; set; }

        public string Password { get; set; }
    }
}
