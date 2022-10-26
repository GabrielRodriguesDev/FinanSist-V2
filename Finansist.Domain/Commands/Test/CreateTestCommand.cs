using Finansist.Domain.Notification;

namespace Finansist.Domain.Commands.Test
{
    public class CreateTestCommand : Notificable
    {
        public String? Descricao { get; set; } = null!;
       
        public PerfilUsuarioEnum? Tipo { get; set; }
        
        public bool Ativo { get; set; }
        public override void Validate()
        {
            if (String.IsNullOrEmpty(this.Descricao))
            {
                this.AddNotification("Descricao", "Informe o Nome");
            }
            else
            {
                if (this.Descricao.Length > 120)
                    this.AddNotification("Descricao", "Nome deve conter no máximo 120 caracteres.");
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