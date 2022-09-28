

using Finansist.Domain.Helpers;
using Finansist.Domain.Notification;

namespace Finansist.Domain.Commands.Autentica
{
    public class LoginCommand : Notificable
    {
        public String? Email { get; set; }
        public String? Senha { get; set; }
        public override void Validate()
        {
            if (String.IsNullOrEmpty(Email))
            {
                AddNotification("Email", "Informe o Email");
            }
            else
            {
                if (Email.Length > 100)
                    AddNotification("Email", "E-mail deve conter no maximo 100 caracteres");

                if (!ValidationHelper.IsValidEmail(Email))
                    AddNotification("Email", "Email digitado está inválido");
            }

            if (String.IsNullOrEmpty(Senha))
            {
                AddNotification("Senha", "Informe a senha");
            }
            else
            {
                if (Senha.Length < 6)
                    AddNotification("Senha", "Senha deve ter no minino 6 digitos.");
            }

        }
    }
}