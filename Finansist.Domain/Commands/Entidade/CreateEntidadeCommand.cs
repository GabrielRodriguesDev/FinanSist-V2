using System.Text.Json.Serialization;
using Finansist.Domain.Helpers;
using Finansist.Domain.Notification;

namespace Finansist.Domain.Commands.Entidade
{
    public class CreateEntidadeCommand : Notificable
    {
        public String Nome { get; set; } = null!;

        public String Descricao { get; set; } = null!;

        public bool Ativo { get; set; }

        public String? CEP { get; set; }

        public String? Logradouro { get; set; }

        public String? Bairro { get; set; }

        public String? Complemento { get; set; }

        public String? Localidade { get; set; }

        public String? UF { get; set; }

        public int? Numero { get; set; }

        [JsonIgnore]
        public bool BuscarCEP { get; set; }



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

            if ((!String.IsNullOrEmpty(CEP)) &&
                (!String.IsNullOrEmpty(Logradouro)) &&
                (!String.IsNullOrEmpty(Bairro)) &&
                (!String.IsNullOrEmpty(Localidade)) &&
                (!String.IsNullOrEmpty(UF)) ||
                (Numero != null))
            {
                this.ValidateAddress();
            }
            else if ((String.IsNullOrEmpty(CEP)) &&
                    (!String.IsNullOrEmpty(Logradouro)) ||
                    (!String.IsNullOrEmpty(Bairro)) ||
                    (!String.IsNullOrEmpty(Localidade)) ||
                    (!String.IsNullOrEmpty(UF)) ||
                    (Numero != null))
            {
                this.ValidateAddress();
            }
            else if ((!String.IsNullOrEmpty(CEP)) &&
                    (String.IsNullOrEmpty(Logradouro)) ||
                    (String.IsNullOrEmpty(Bairro)) ||
                    (String.IsNullOrEmpty(Localidade)) ||
                    (String.IsNullOrEmpty(UF)) ||
                    (Numero != null))
            {
                if (String.IsNullOrEmpty(this.CEP))
                {
                    this.AddNotification("CEP", "Informe o CEP");
                }
                else
                {
                    if (this.CEP.Length > 8)
                    {
                        this.AddNotification("CEP", "CEP deve conter no máximo 8 caracteres.");
                    }
                    else if (!ValidationHelper.IsValidCEP(CEP))
                    {
                        this.AddNotification("CEP", "Infome um CEP válido.");
                    }
                    else
                    {
                        this.BuscarCEP = true;
                    }
                }
            }
        }

        public void ValidateAddress()
        {


            if (String.IsNullOrEmpty(this.CEP))
            {
                this.AddNotification("CEP", "Informe o CEP");
            }
            else
            {
                if (this.CEP.Length > 8)
                {
                    this.AddNotification("CEP", "CEP deve conter no máximo 8 caracteres.");
                }
                else if (!ValidationHelper.IsValidCEP(CEP))
                {
                    this.AddNotification("CEP", "Infome um CEP válido.");
                }
            }

            if (String.IsNullOrEmpty(this.Logradouro))
            {
                this.AddNotification("Logradouro", "Informe o Logradouro");
            }
            else
            {
                if (this.Logradouro.Length > 120)
                    this.AddNotification("Logradouro", "Logradouro deve conter no máximo 120 caracteres.");
            }

            if (String.IsNullOrEmpty(this.Bairro))
            {
                this.AddNotification("Bairro", "Informe o Bairro");
            }
            else
            {
                if (this.Bairro.Length > 120)
                    this.AddNotification("Bairro", "Bairro deve conter no máximo 120 caracteres.");
            }

            if (!String.IsNullOrEmpty(Complemento))
            {
                if (this.Complemento.Length > 120)
                    this.AddNotification("Complemento", "Complemento deve conter no máximo 120 caracteres.");
            }

            if (String.IsNullOrEmpty(this.Localidade))
            {
                this.AddNotification("Localidade", "Informe o Localidade");
            }
            else
            {
                if (this.Localidade.Length > 120)
                    this.AddNotification("Localidade", "Localidade deve conter no máximo 120 caracteres.");
            }

            if (String.IsNullOrEmpty(this.UF))
            {
                this.AddNotification("UF", "Informe o UF");
            }
            else
            {
                if (this.UF.Length > 2)
                    this.AddNotification("UF", "UF deve conter no máximo 2 caracteres.");
            }

            if (this.Numero != null)
            {
                if (this.Numero > 999999)
                    this.AddNotification("Numero", "Número máximo permitido é 999999.");
            }
        }
    }
}
