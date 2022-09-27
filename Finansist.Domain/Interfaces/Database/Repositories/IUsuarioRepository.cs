using Finansist.Domain.Entities;

namespace Finansist.Domain.Interfaces.Database.Repositories
{
    public interface IUsuarioRepository : IBaseRepository<Usuario>
    {
        Usuario GetPorEmail(string email);
    }
}