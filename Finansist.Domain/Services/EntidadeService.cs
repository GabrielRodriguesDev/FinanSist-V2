using Finansist.Domain.Commands;
using Finansist.Domain.Commands.Entidade;
using Finansist.Domain.Entities;
using Finansist.Domain.Interfaces.CrossCutting.Interfaces.Clients;
using Finansist.Domain.Interfaces.Database.Helpers;
using Finansist.Domain.Interfaces.Database.Repositories;
using Finansist.Domain.Interfaces.Domain.Services;
using Finansist.Domain.Models.Clients;

namespace Finansist.Domain.Services
{
    public class EntidadeService : IEntidadeService
    {
        private IEntidadeRepository _entidadeRepository;

        private IViaCEPClient _viaCEPClient;

        private IControleSequenciaHelper _controleSequenciaHelper;

        public EntidadeService(
            IEntidadeRepository entidadeRepository,
            IViaCEPClient viaCEPClient,
            IControleSequenciaHelper controleSequenciaHelper
        )
        {
            _entidadeRepository = entidadeRepository;
            _viaCEPClient = viaCEPClient;
            _controleSequenciaHelper = controleSequenciaHelper;
        }


        public async Task<GennericCommandResult> Create(CreateEntidadeCommand createCommand)
        {
            createCommand.Validate();
            if (createCommand.Invalid)
                return new GennericCommandResult(false, "Ops! Algo deu errado");

            Entidade entidade = new Entidade(createCommand);

            if (createCommand.BuscarCEP)
            {
                var result = await _viaCEPClient.GetEnderecoAsync(createCommand.CEP!);
                if (!result.Sucess && result.Data == null)
                {
                    return new GennericCommandResult(false, "Não foi possivel localizar o cep");
                }

                entidade.setEndereco(result.Data as EnderecoModel);
   
            }

            entidade.setCodigoInterno(_controleSequenciaHelper.ProcessoNumeroSequencial("Entidade"));

            var teste = "teste";

            try
            {

            }
            catch (System.Exception)
            {

                throw;
            }
            return new GennericCommandResult(true, "Entidade criada com sucesso", new { });
        }
    }
}