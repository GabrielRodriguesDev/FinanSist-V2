using Finansist.Database.Contexts;
using Finansist.Domain.Entities;
using Finansist.Domain.Interfaces.Database;
using Finansist.Domain.Interfaces.Database.Repositories;

namespace Finansist.Database.Repositories
{
    public class EntidadeRepository : BaseRepository<Entidade>, IEntidadeRepository
    {
        public EntidadeRepository(FinansistContext context, IUnitOfWork uow) : base(context, uow)
        {
        }
    }
}