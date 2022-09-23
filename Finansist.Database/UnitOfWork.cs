using System.Data;
using Finansist.Database.Contexts;
using Finansist.Domain.Interfaces.Database;
using Microsoft.EntityFrameworkCore.Storage;

namespace Finansist.Database
{
    public class UnitOfWork : IUnitOfWork
    {
#nullable disable

        private FinansistContext _context;
        private IDbContextTransaction _dbContextTransaction;

        public UnitOfWork(FinansistContext context)
        {
            _context = context;
        }
        public void BeginTransaction()
        {
            _dbContextTransaction = _context.Database.BeginTransaction();
        }

        public void Commit()
        {
            if (_dbContextTransaction == null)
                throw new Exception("Transação não iniciada");

            _context.SaveChangesAsync().Wait();
            _dbContextTransaction.CommitAsync().Wait();
            _context.ChangeTracker.Clear();
            _dbContextTransaction = null;
        }

        public IDbTransaction CurrentTransaction()
        {
            IDbTransaction result = null;
            if (_dbContextTransaction != null)
            {
                result = _dbContextTransaction.GetDbTransaction();
            }
            return result;
        }

        public void Rollback()
        {
            if (_dbContextTransaction != null)
            {
                _dbContextTransaction.RollbackAsync().Wait();
            }
        }
    }
}
