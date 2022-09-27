using Finansist.Domain.Commands;
using Finansist.Domain.Commands.Entidade;
using Finansist.Domain.Entities;
using Finansist.Domain.Interfaces.CrossCutting.Interfaces.Clients;
using Finansist.Domain.Interfaces.Database;
using Finansist.Domain.Interfaces.Database.Helpers;
using Finansist.Domain.Interfaces.Database.Repositories;
using Finansist.Domain.Interfaces.Domain.Services;
using Finansist.Domain.Models.Clients;

namespace Finansist.Domain.Services
{
    public class EntidadeService : IEntidadeService
    {
        private IEntidadeRepository _entidadeRepository;

        private IUnitOfWork _uow;

        private IViaCEPClient _viaCEPClient;

        private IControleSequenciaHelper _controleSequenciaHelper;

        public EntidadeService(
            IUnitOfWork uow,
            IEntidadeRepository entidadeRepository,
            IViaCEPClient viaCEPClient,
            IControleSequenciaHelper controleSequenciaHelper
        )
        {
            _uow = uow;
            _entidadeRepository = entidadeRepository;
            _viaCEPClient = viaCEPClient;
            _controleSequenciaHelper = controleSequenciaHelper;
        }


        public async Task<GenericCommandResult> Create(CreateEntidadeCommand createCommand)
        {
            createCommand.Validate();
            if (createCommand.Invalid)
                return new GenericCommandResult(false, "Ops! Algo deu errado", createCommand.Notifications);

            Entidade entidade = new Entidade(createCommand);

            if (createCommand.BuscarCEP)
            {
                var result = await _viaCEPClient.GetEnderecoAsync(createCommand.CEP!);
                if (!result.Sucess && result.Data == null)
                {
                    return new GenericCommandResult(false, result.Message);
                }
                entidade.setEndereco(result.Data as EnderecoModel);
            }

            entidade.setCodigoInterno(_controleSequenciaHelper.ProcessoNumeroSequencial(entidade.GetType().Name.ToString()));

            _uow.BeginTransaction();

            try
            {
                _entidadeRepository.Create(entidade);
                _uow.Commit();
            }
            catch (System.Exception)
            {
                _uow.Rollback();
                throw;
            }
            return new GenericCommandResult(true, "Entidade criada com sucesso", new
            {
                Id = entidade.Id,
                CodigoInterno = entidade.CodigoInterno,
                Nome = entidade.Nome,
                Descricao = entidade.Descricao,
                Ativo = entidade.Ativo,
                CEP = entidade.CEP,
                Logradouro = entidade.Logradouro,
                Bairro = entidade.Bairro,
                Complemento = entidade.Complemento,
                Localidade = entidade.Localidade,
                UF = entidade.UF,
                Numero = entidade.Numero,
            });
        }
    }
}