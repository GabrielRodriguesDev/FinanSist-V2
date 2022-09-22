using Finansist.Database.Contexts;
using Finansist.Domain.Entities;
using Finansist.Domain.Interfaces.Database.Repositories;

namespace Finansist.Database.Repositories
{
    public class EntidadeRepository : BaseRepository<Entidade>, IEntidadeRepository
    {
        public EntidadeRepository(FinansistContext context) : base(context)
        {
        }
    }
}