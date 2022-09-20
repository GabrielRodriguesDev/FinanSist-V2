using Finansist.Domain.Commands;
using Finansist.Domain.Commands.Entidade;

namespace Finansist.Domain.Interfaces.Domain.Services
{
    public interface IEntidadeService
    {
        GennericCommandResult Create(CreateEntidadeCommand createCommand);
    }
}