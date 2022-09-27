using Dapper;
using Finansist.Database.Contexts;
using Finansist.Domain.Entities;
using Finansist.Domain.Interfaces.Database;
using Finansist.Domain.Interfaces.Database.Repositories;
using Finansist.Domain.Queries;

namespace Finansist.Database.Repositories
{
    public class UsuarioRepository : BaseRepository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(FinansistContext context, IUnitOfWork uow) : base(context, uow)
        {
        }

        public Usuario GetPorEmail(string email)
        {
            return _connection.QueryFirstOrDefault<Usuario>(UsuarioQueries.GetPorEmail(), new { Email = email });
        }
    }
}