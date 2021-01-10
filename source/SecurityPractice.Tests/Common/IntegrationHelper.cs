namespace SecurityPractice.Tests.Common
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using SecurityPractice.Domain.Customers.Models;
    using SecurityPractice.Infrastructure.DataAccess.Common;
    using Serilog;

    public static class IntegrationHelper
    {
        public static void ClearDatabase()
        {
            using (var context = ServiceProvider().GetRequiredService<ApplicationContext>())
            {
                var users = context.Users;

                context.Users.RemoveRange(users);

                context.SaveChanges();
            }
        }

        public static ApplicationContext ApplicationContext()
        {
            return ServiceProvider().GetRequiredService<ApplicationContext>();
        }

        public static UserManager<Customer> UserManager()
        {
            return ServiceProvider().GetRequiredService<UserManager<Customer>>();
        }

        private static ServiceProvider ServiceProvider()
        {
            var collection = new ServiceCollection();

            collection.AddDbContext<ApplicationContext>(x =>
            {
                x.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=SecurityPractice.Development;Trusted_Connection=True;MultipleActiveResultSets=true");
            });

            collection.AddAuthentication();

            var logger = new LoggerConfiguration()
                .MinimumLevel.Error()
                .WriteTo.Console()
                .CreateLogger();

            collection.AddLogging();

            collection.AddSingleton<Serilog.ILogger>(_ => logger);

            collection.AddIdentity<Customer, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationContext>()
                .AddDefaultTokenProviders();

            var provider = collection.BuildServiceProvider();

            return collection.BuildServiceProvider();
        }
    }
}
