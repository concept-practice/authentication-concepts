namespace SecurityPractice.Domain.Customers.IsUsernameAvailable
{
    public class IsUsernameAvailableResponse
    {
        public IsUsernameAvailableResponse(bool usernameIsAvailable)
        {
            UsernameIsAvailable = usernameIsAvailable;
        }

        public bool UsernameIsAvailable { get; }
    }
}
