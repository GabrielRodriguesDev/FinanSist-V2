using Finansist.Domain.Commands;
using Finansist.Domain.Models.Clients;
using Refit;

namespace Finansist.Domain.Interfaces.CrossCutting.Interfaces.Clients
{
    public interface IViaCEPClient
    {
        Task<GennericCommandResult> GetEnderecoAsync(string cep);
    }
}