namespace SecurityPractice.Infrastructure.DataAccess.Common
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using SecurityPractice.Domain.Customers.Models;

    public sealed class ApplicationContext : IdentityDbContext<Customer>
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //builder.BuildCustomer();
        }
    }
}
