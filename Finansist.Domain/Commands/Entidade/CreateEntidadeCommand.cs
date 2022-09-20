using Finansist.Domain.Notification;

namespace Finansist.Domain.Commands.Entidade
{
    public class CreateEntidadeCommand : Notificable
    {
        public String Nome { get; set; } = null!;

        public String Descricao { get; set; } = null!;

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

            if (String.IsNullOrEmpty(this.Descricao))
            {
                this.AddNotification("Descricao", "Informe a Descrição");
            }
            else
            {
                if (this.Nome.Length > 120)
                    this.AddNotification("Descricao", "Descrição deve conter no máximo 150 caracteres.");
            }
        }
    }
}