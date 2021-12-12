namespace SecurityPractice.Infrastructure.Dependencies
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using Domain.Customers.Models;
    using MediatR;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using SecurityPractice.Infrastructure.DataAccess.Common;
    using Serilog;

    public static class Bootstrapper
    {
        public static void Register(this IServiceCollection services)
        {
            services.AddDbContext<ApplicationContext>(x =>
            {
                x.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=SecurityPractice;Trusted_Connection=True;MultipleActiveResultSets=true");
            });

            services.AddIdentity<Customer, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationContext>()
                .AddDefaultTokenProviders();

            services
                .AddAuthentication()
                .AddCookie();

            var logger = new LoggerConfiguration()
                .MinimumLevel.Error()
                .WriteTo.Console()
                .CreateLogger();

            services.AddLogging();

            services.AddSingleton<ILogger>(_ => logger);

            services.AddMediatR(Assembly.Load("SecurityPractice.Domain"), Assembly.Load("SecurityPractice.Infrastructure"));

            GetTypes("SecurityPractice.Infrastructure", "Repository")
                .ForEach(type => services.AddTransient(type.GetInterfaces().First(x => x.Name.EndsWith("Repository")), type));

            GetTypes("SecurityPractice.Domain", "Factory")
                .ForEach(type => services.AddTransient(type.GetInterfaces().First(), type));
        }

        public static List<Type> GetTypes(string assembly, string typeName)
        {
            return Assembly.Load(assembly)
                .GetTypes()
                .Where(type => !type.IsAbstract || !type.IsInterface)
                .Where(type => type.Name.EndsWith(typeName))
                .ToList();
        }
    }
}
