
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        //IDbContextTransaction BeginTransaction(IsolationLevel level = IsolationLevel.RepeatableRead);

        IProductRepository ProductRepository { get; }

        Task Save();
    }
    
}
