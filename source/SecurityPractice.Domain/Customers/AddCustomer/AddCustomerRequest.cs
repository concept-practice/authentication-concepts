namespace SecurityPractice.Domain.Customers.AddCustomer
{
    using System.ComponentModel.DataAnnotations;
    using MediatR;

    public class AddCustomerRequest : IRequest
    {
        [Required(AllowEmptyStrings = false)]
        public string FirstName { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string LastName { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string Username { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string Password { get; set; }
    }
}
