using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence
{
    internal class ApplicationDBContextFactory : IDesignTimeDbContextFactory<ApplicationDBContext>
    {
        public ApplicationDBContext CreateDbContext(string[] args)
        {
            /* string pathToContentRoot = Directory.GetCurrentDirectory();
             string json = Path.Combine(pathToContentRoot, "appsettings.json");

             if (!File.Exists(json))
             {
                 string pathToExe = Process.GetCurrentProcess().MainModule.FileName;
                 pathToContentRoot = Path.GetDirectoryName(pathToExe);
             }

             IConfigurationRoot configuration = new ConfigurationBuilder()
                 // .SetBasePath(Directory.GetCurrentDirectory())
                  .SetBasePath(pathToContentRoot)
                  .AddJsonFile("appsettings.json")
                  .Build();*/

            /*
            var builder = new DbContextOptionsBuilder<ApplicationDBContext>();
            var connectionString = configuration.GetConnectionString("CleanArchDatabaseConnectionString");

            builder.UseSqlServer(connectionString);

            return new ApplicationDBContext(builder.Options);*/
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDBContext>();
            optionsBuilder.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=dbtecos;");

            return new ApplicationDBContext(optionsBuilder.Options);
        }

    }
}
