using Finansist.Domain.Commands;
using Finansist.Domain.Commands.Entidade;

namespace Finansist.Domain.Interfaces.Domain.Services
{
    public interface IEntidadeService
    {
        Task<GennericCommandResult> Create(CreateEntidadeCommand createCommand);
    }
}