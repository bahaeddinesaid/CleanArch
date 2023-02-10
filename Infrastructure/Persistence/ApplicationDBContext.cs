using Application.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence
{
    public class ApplicationDBContext : DbContext
    {
        #region Constructor
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options)
         : base(options)
        {
        }
        #endregion

/*protected override void OnConfiguring(DbContextOptionsBuilder builder)

        {

            base.OnConfiguring(builder);



            if (!builder.IsConfigured)

            {

                builder.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=master;");

            }

            builder.UseSqlServer(x => x.MigrationsHistoryTable("__Clb_EFMigrationsHistory", "dbo"));

        }*/

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDBContext).Assembly);
        }

        #region DbSet
        public DbSet<Product> Products { get; set; }
        #endregion

        #region Methods
        //public Task<int> SaveChangesAsync()
       // {
        //    return base.SaveChangesAsync();
       // }
        #endregion
    }
}
