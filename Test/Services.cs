using Core.Services.Users;
using Core.Data;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reqnroll.Microsoft.Extensions.DependencyInjection;
using Reqnroll;
using Microsoft.EntityFrameworkCore;

namespace Test
{
    public static class Services
    {
        [ScenarioDependencies]
        public static IServiceCollection CreateServices()
        {
            var services = new ServiceCollection();

            //Add db-context
            services.AddDbContext<Database>(options =>
                options.UseInMemoryDatabase("TestDb"));

            // Add services
            services.AddScoped<IDatabase, Database>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IEventService, EventService>();
            services.AddScoped<ITicketService, TicketService>();
            services.AddScoped<IAuthService, AuthService>();

            // Build the service provider and initialize the database
            var serviceProvider = services.BuildServiceProvider();
            var dbContext = serviceProvider.GetRequiredService<Database>();
            dbContext.Database.EnsureCreated();

            return services;
        }
    }
}
