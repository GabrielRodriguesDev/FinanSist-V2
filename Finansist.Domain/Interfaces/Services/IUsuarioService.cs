using Finansist.Domain.Commands;
using Finansist.Domain.Commands.Result;
using Finansist.Domain.Commands.Usuario;

namespace Finansist.Domain.Interfaces.Services
{
    public interface IUsuarioService
    {
        Object? Create(CreateUsuarioCommand createCommand);
    }
}