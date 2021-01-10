namespace SecurityPractice.Domain.Customers.IsUsernameAvailable
{
    using MediatR;

    public class IsUsernameAvailableRequest : IRequest<IsUsernameAvailableResponse>
    {
        public IsUsernameAvailableRequest(string username)
        {
            Username = username;
        }

        public string Username { get; }
    }
}
