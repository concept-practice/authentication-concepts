namespace SecurityPractice.Domain.Customers.Models
{
    using Microsoft.AspNetCore.Identity;

    public sealed class Customer : IdentityUser
    {
        public Customer(string userName, string firstName, string lastName, string email)
            : this()
        {
            UserName = userName;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
        }

        private Customer()
        {
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}
