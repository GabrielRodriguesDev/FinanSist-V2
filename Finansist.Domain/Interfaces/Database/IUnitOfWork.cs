using System.Data;

namespace Finansist.Domain.Interfaces.Database
{
    public interface IUnitOfWork
    {
        void BeginTransaction();
        void Commit();
        void Rollback();
        IDbTransaction CurrentTransaction();
    }
}