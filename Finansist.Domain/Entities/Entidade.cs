using Finansist.Domain.Commands.Entidade;
using Finansist.Domain.Models.Clients;

namespace Finansist.Domain.Entities
{
    public class Entidade : BaseEntity
    {
        public Entidade()
        {

        }

        public Entidade(CreateEntidadeCommand createCommand)
        {
            this.Nome = createCommand.Nome;
            this.Descricao = createCommand.Descricao;
            this.CEP = createCommand.CEP;
            this.Logradouro = createCommand.Logradouro;
            this.Bairro = createCommand.Bairro;
            this.Complemento = createCommand.Complemento;
            this.Localidade = createCommand.Localidade;
            this.UF = createCommand.UF;
            this.Numero = createCommand.Numero;
            this.Ativo = createCommand.Ativo;
        }

        public String Nome { get; private set; } = null!;

        public String Descricao { get; private set; } = null!;

        public int CodigoInterno { get; private set; }

        public bool Ativo { get; private set; }

        public String? CEP { get; private set; }

        public String? Logradouro { get; private set; }

        public String? Bairro { get; private set; }

        public String? Complemento { get; private set; }

        public String? Localidade { get; private set; }

        public String? UF { get; private set; }

        public int? Numero { get; private set; }

        public void setCodigoInterno(int codigoInterno)
        {
            this.CodigoInterno = codigoInterno;
        }

        public void setEndereco(EnderecoModel? endereco)
        {
            this.CEP = endereco!.CEP.Replace("-", "");
            this.Logradouro = endereco.Logradouro;
            this.Bairro = endereco.Bairro;
            this.Complemento = endereco.Complemento;
            this.Localidade = endereco.Localidade;
            this.UF = endereco.UF;
        }
    }
}
