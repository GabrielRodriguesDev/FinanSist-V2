using Finansist.Domain.Commands;
using Finansist.Domain.Commands.Usuario;

namespace Finansist.Domain.Interfaces.Domain.Services
{
    public interface IUsuarioService
    {
        GenericCommandResult Create(CreateUsuarioCommand createCommand);
    }
}