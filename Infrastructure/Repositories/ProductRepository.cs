using Application.Interfaces.Repository;
using Domain.Entities;
using Infrastructure.Persistence;
using Infrastructure.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(ApplicationDBContext dbContext) : base(dbContext)
        {
        }
    }
}
