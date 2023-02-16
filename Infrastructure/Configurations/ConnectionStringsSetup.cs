using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Configurations
{
   
    public static class ConnectionStringsSetup
    {

         /*public static ConfigureHostBuilder AddConfigurations(this ConfigureHostBuilder host)
        {
            host.ConfigureAppConfiguration((context, config) =>
            {
               
                const string configurationsDirectory = "Configurations"; // Path for pickup location of configuration files
                var env = context.HostingEnvironment; // Get current hosting environment

                // Application Specific Configurations
                // config.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                //  .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true, reloadOnChange: true)
                config.AddJsonFile($"{configurationsDirectory}/connectionStrings.json", optional: false, reloadOnChange: true)
                    //.AddJsonFile($"{configurationsDirectory}/connectionStrings.{env.EnvironmentName}.json", optional: true, reloadOnChange: true)
                    .AddEnvironmentVariables();
            });
            return host;
        }

        public static IServiceCollection AddConfigurationServices(this IServiceCollection services, IConfiguration configuration)
        {
            //services.Configure<ConfigurationOptions>(options => configuration.GetSection("ConnectionStrings").Bind(options));
            services.Configure<ConfigurationOptions>(options => configuration.Bind(options));
            return services;
        }*/
    }
}
