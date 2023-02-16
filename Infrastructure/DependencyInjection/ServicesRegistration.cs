using Application.Interfaces;
using Application.Interfaces.Common;
using Application.Interfaces.Repository;
using Application.Logging;
using Infrastructure.Configurations;
using Infrastructure.Persistence;
using Infrastructure.Repositories;
using Infrastructure.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Serilog;
using Serilog.Events;
using Serilog.Formatting.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DependencyInjection
{
    public static class ServicesRegistration
    {

        public static IServiceCollection ConfigurePersistenceServices(this IServiceCollection services,
            IConfiguration configuration)
        {
            const string configurationsDirectory = "/Configurations/"; // Path for pickup location of configuration files

            // build config
            var configurationB = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory()+ configurationsDirectory)
                .AddJsonFile("connectionStrings.json", optional: false, reloadOnChange: true)
                .AddJsonFile("prop2.json", optional: false, reloadOnChange: true)
                .AddJsonFile("Serilog.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables()
                .Build();

            

            //services.ConfigureOptions<ConfigurationOptions>();
            //services.Configure<ConfigurationOptions>(options => configurationB.GetSection("ConnectionStrings").Bind(options));
            services.Configure<ConfigurationOptions>(options => configurationB.Bind(options));


            services.AddDbContext<ApplicationDBContext>(options =>
               options.UseSqlServer(
                   //configuration.GetConnectionString("CleanArchDatabaseConnectionString")
                   //configurationB.GetSection("ConnectionStrings").Value                   
                     configurationB.GetConnectionString("CleanArchDatabaseConnectionString")   
                   ));


            
            services.AddScoped(typeof(LoggingBehaviour<,>));


            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();


            services.AddScoped<IProductRepository, ProductRepository>();

            return services;
        }
    }
}
