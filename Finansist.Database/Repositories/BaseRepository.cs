using System.Data.Common;
using Dapper;
using Finansist.Database.Contexts;
using Finansist.Domain.Entities;
using Finansist.Domain.Interfaces.Database;
using Finansist.Domain.Interfaces.Database.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Finansist.Database.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        protected FinansistContext _context;

        protected IUnitOfWork _uow;

        protected DbSet<TEntity> _dbSet;

        protected DbConnection _connection;

        public BaseRepository(FinansistContext context, IUnitOfWork uow)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
            _connection = _context.Database.GetDbConnection();
            _uow = uow;

        }

        public Guid Create(TEntity entity)
        {
            _dbSet.Add(entity);
            return entity.Id;
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public bool ExistePorId(Guid? id)
        {
            throw new NotImplementedException();
        }

        public TEntity? Get(Guid id)
        {
            //return _dbSet.Where(entity => entity.Id == id).FirstOrDefault();
            return _connection.QueryFirstOrDefault<TEntity>($@"Select * From {typeof(TEntity).Name} Where Id = @Id", new { Id = id });
        }

        public IEnumerable<TEntity> GetAll()
        {
            throw new NotImplementedException();
        }

        public int GetCount(bool executarAtivo = true)
        {
            throw new NotImplementedException();
        }

        public dynamic GetRetornaCampo(Guid? id, string campo)
        {
            return _connection.QueryFirstOrDefault($"Select {campo} From {typeof(TEntity).Name} Where Id = @Id", new { Id = id }, _uow.CurrentTransaction());
        }

        public void Update(TEntity entity)
        {
            _dbSet.Update(entity);
        }
    }
}