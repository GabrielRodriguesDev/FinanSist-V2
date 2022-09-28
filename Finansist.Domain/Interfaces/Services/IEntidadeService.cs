using Finansist.Domain.Commands;
using Finansist.Domain.Commands.Entidade;
using Finansist.Domain.Commands.Result;

namespace Finansist.Domain.Interfaces.Services
{
    public interface IEntidadeService
    {
        Task<GenericCommandResult> Create(CreateEntidadeCommand createCommand);
    }
}