
using Finansist.Domain.Commands;
using Finansist.Domain.Commands.Autentica;
using Finansist.Domain.Commands.Result;
using Finansist.Domain.Interfaces.Database;
using Finansist.Domain.Interfaces.Database.Repositories;
using Finansist.Domain.Interfaces.Services;
using Finansist.Domain.Models.ValueObjects;

namespace Finansist.Domain.Services
{
    public class AutenticaService : IAutenticaService
    {
        private IUnitOfWork _uow;

        private IUsuarioRepository _usuarioRepository;

        public AutenticaService(IUsuarioRepository usuarioRepository, IUnitOfWork uow)
        {
            _usuarioRepository = usuarioRepository;
            _uow = uow;
        }
        public LoginCommandResult Login(LoginCommand command)
        {
            command.Validate();
            if (command.Invalid)
                return new LoginCommandResult(false, "Ops! Algo deu errado", command.Notifications);

            var usuario = _usuarioRepository.GetPorEmail(command.Email!);
            if (usuario is null) return new LoginCommandResult(false, "E-mail não localizado.");

            if (!usuario.VerificarSenha(command.Senha!)) return new LoginCommandResult(false, "Usuário ou senha inválidos");

            if (usuario.ExigirNovaSenha == true)
            {
                usuario.AlterarSenha("Fx@870Fx@870");
                usuario.setExigirNovaSenha(false);

                _uow.BeginTransaction();

                try
                {
                    _usuarioRepository.Update(usuario);
                    _uow.Commit();
                }
                catch (System.Exception)
                {
                    _uow.Rollback();
                    throw;
                }
            }
            Autenticado autenticado = new Autenticado(usuario);
            return new LoginCommandResult(true, "Usuário autenticado com sucesso.", null, autenticado);
        }
    }
}