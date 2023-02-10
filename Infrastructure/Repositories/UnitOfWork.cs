using Application.Interfaces.Repository;
using Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDBContext _context;
        public IProductRepository _productRepository ;


        public UnitOfWork(ApplicationDBContext context)
        {
            _context = context;
        }

        public IProductRepository ProductRepository =>
            _productRepository ??= new ProductRepository(_context);


        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
