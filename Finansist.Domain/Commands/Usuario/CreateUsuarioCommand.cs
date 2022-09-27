using Finansist.Domain.Helpers;
using Finansist.Domain.Notification;

namespace Finansist.Domain.Commands.Usuario
{
    public class CreateUsuarioCommand : Notificable
    {
        public String? Nome { get; set; } = null!;
        public String? Email { get; set; } = null!;
        public PerfilUsuarioEnum? Tipo { get; set; }
        public String Telefone { get; set; } = null!;
        public bool Ativo { get; set; }
        public override void Validate()
        {
            if (String.IsNullOrEmpty(this.Nome))
            {
                this.AddNotification("Nome", "Informe o Nome");
            }
            else
            {
                if (this.Nome.Length > 120)
                    this.AddNotification("Nome", "Nome deve conter no máximo 120 caracteres.");
            }

            if (String.IsNullOrEmpty(this.Email))
            {
                this.AddNotification("E-mail", "Informe o E-mail.");
            }
            else
            {
                if (!ValidationHelper.IsValidEmail(this.Email!))
                    this.AddNotification("E-mail", "Informe um E-mail válido.");

                if (this.Email!.Length > 150)
                    this.AddNotification("E-mail", "E-mail deve conter no máximo 120 caracteres.");
            }

            if (!String.IsNullOrEmpty(this.Telefone))
            {
                if (!ValidationHelper.IsValidTelefone(this.Telefone))
                    this.AddNotification("Telefone", "Informe um Telefone válido.");

                if (this.Telefone!.Length > 15)
                    this.AddNotification("Telefone", "Telefone deve conter no máximo 15 caracteres.");
            }

            if (this.Tipo == null)
            {
                this.AddNotification("Tipo", "Informe o tipo.");
            }
            else
            {
                bool result = false;
                foreach (var perfilUsuario in Enum.GetValues(typeof(PerfilUsuarioEnum)))
                {
                    if ((int)this.Tipo == (int)perfilUsuario)
                    {
                        result = true;
                    }
                }
                if (result == false)
                {
                    this.AddNotification("Tipo", "Informe um tipo de Usuario válido.");
                }
            }
        }
    }
}