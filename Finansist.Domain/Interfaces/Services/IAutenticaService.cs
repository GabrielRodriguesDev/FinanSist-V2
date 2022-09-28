using Finansist.Domain.Commands;
using Finansist.Domain.Commands.Autentica;
using Finansist.Domain.Commands.Result;

namespace Finansist.Domain.Interfaces.Services
{
    public interface IAutenticaService
    {
        LoginCommandResult Login(LoginCommand command);
    }
}