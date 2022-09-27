using Finansist.Domain.Commands;
using Finansist.Domain.Commands.Usuario;
using Finansist.Domain.Entities;
using Finansist.Domain.Interfaces.CrossCutting.Interfaces.Clients;
using Finansist.Domain.Interfaces.Database;
using Finansist.Domain.Interfaces.Database.Helpers;
using Finansist.Domain.Interfaces.Database.Repositories;
using Finansist.Domain.Interfaces.Domain.Services;


namespace Finansist.Domain.Services
{
    public class UsuarioService : IUsuarioService
    {
        private IUsuarioRepository _UsuarioRepository;

        private IUnitOfWork _uow;

        private IViaCEPClient _viaCEPClient;

        private IControleSequenciaHelper _controleSequenciaHelper;

        public UsuarioService(
            IUnitOfWork uow,
            IUsuarioRepository UsuarioRepository,
            IViaCEPClient viaCEPClient,
            IControleSequenciaHelper controleSequenciaHelper
        )
        {
            _uow = uow;
            _UsuarioRepository = UsuarioRepository;
            _viaCEPClient = viaCEPClient;
            _controleSequenciaHelper = controleSequenciaHelper;
        }


        public GenericCommandResult Create(CreateUsuarioCommand createCommand)
        {
            createCommand.Validate();
            if (createCommand.Invalid)
                return new GenericCommandResult(false, "Ops! Algo deu errado", createCommand.Notifications);

            var usuariodb = _UsuarioRepository.GetPorEmail(createCommand.Email!);
            if (usuariodb != null) return new GenericCommandResult(false, $"Desculpe, E-mail ({createCommand.Email}) já cadastrado.");

            Usuario usuario = new Usuario(createCommand);

            _uow.BeginTransaction();
            try
            {
                _UsuarioRepository.Create(usuario);
                _uow.Commit();
            }
            catch (System.Exception)
            {
                _uow.Rollback();
                throw;
            }
            return new GenericCommandResult(true, $"Usuário {usuario.Nome} cadastrado com sucesso", new
            {
                Nome = usuario.Nome,
                Email = usuario.Email,
                Telefone = usuario.Telefone,
                SenhaTemporaria = usuario.Senha,
                Ativo = usuario.Ativo
            });
        }
    }
}