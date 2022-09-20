using Finansist.Domain.Entities;

namespace Finansist.Domain.Interfaces.Database.Repositories
{
    public interface IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        Guid Create(TEntity entity);
        void Update(TEntity entity);
        void Delete(Guid id);
        TEntity? Get(Guid id);
        int GetCount(bool executarAtivo = true);
        bool ExistePorId(Guid? id);
        dynamic? GetRetornaCampo(Guid? id, string campo);
        IEnumerable<TEntity> GetAll();
    }
}