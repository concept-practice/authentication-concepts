namespace SecurityPractice.Infrastructure.DataAccess.Customers
{
    using Microsoft.EntityFrameworkCore;
    using SecurityPractice.Domain.Customers.Models;

    public static class CustomerBuilder
    {
        public static ModelBuilder BuildCustomer(this ModelBuilder builder)
        {
            builder.Entity<Customer>(typeBuilder =>
            {
                typeBuilder.HasKey(customer => customer.Id);
                typeBuilder.Property(customer => customer.FirstName);
                typeBuilder.Property(customer => customer.LastName);
            });

            return builder;
        }
    }
}
