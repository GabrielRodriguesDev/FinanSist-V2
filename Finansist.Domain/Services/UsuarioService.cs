using Finansist.Domain.Commands.Result;
using Finansist.Domain.Commands.Usuario;
using Finansist.Domain.Entities;
using Finansist.Domain.Interfaces.Database;
using Finansist.Domain.Interfaces.Database.Helpers;
using Finansist.Domain.Interfaces.Database.Repositories;
using Finansist.Domain.Interfaces.Services;

namespace Finansist.Domain.Services
{
    public class UsuarioService : IUsuarioService
    {
        private IUsuarioRepository _usuarioRepository;

        private IUnitOfWork _uow;

        private IControleSequenciaHelper _controleSequenciaHelper;

        public UsuarioService(
            IUnitOfWork uow,
            IUsuarioRepository usuarioRepository,
            IControleSequenciaHelper controleSequenciaHelper
        )
        {
            _uow = uow;
            _usuarioRepository = usuarioRepository;
            _controleSequenciaHelper = controleSequenciaHelper;
        }


        public GenericCommandResult Create(CreateUsuarioCommand createCommand)
        {
            createCommand.Validate();
            if (createCommand.Invalid)
                return new GenericCommandResult(false, "Ops! Algo deu errado", createCommand.Notifications);

            var usuariodb = _usuarioRepository.GetPorEmail(createCommand.Email!);
            if (usuariodb != null) return new GenericCommandResult(false, $"Desculpe, E-mail ({createCommand.Email}) já cadastrado.");

            Usuario usuario = new Usuario(createCommand);
            var senhaTemporaria = usuario.Senha;
            usuario.AlterarSenha(usuario.Senha);
            _uow.BeginTransaction();
            try
            {
                _usuarioRepository.Create(usuario);
                _uow.Commit();
            }
            catch (System.Exception)
            {
                _uow.Rollback();
                throw;
            }
            return new GenericCommandResult(true, $"Usuário {usuario.Nome} cadastrado com sucesso.", new
            {
                Nome = usuario.Nome,
                Email = usuario.Email,
                Telefone = usuario.Telefone,
                SenhaTemporaria = senhaTemporaria,
                Ativo = usuario.Ativo
            });
        }
    }
}