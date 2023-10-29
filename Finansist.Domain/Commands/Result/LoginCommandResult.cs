using Finansist.Domain.Models.ValueObjects;

namespace Finansist.Domain.Commands.Result
{
    public class LoginCommandResult
    {

        public LoginCommandResult(bool sucess, string message, object? data, Autenticado? autenticado = null)
        {
            Sucess = sucess;
            Autenticado = autenticado!;
        }

        public LoginCommandResult(bool sucess, string message)
        {
            Sucess = sucess;
            Message = message;
         
        }

        public bool Sucess { get; set; }

        public String Message { get; set; } = null!;

        public Autenticado Autenticado { get; set; } = null!;

        public Object? Data { get; set; } = null!;
    }
}
