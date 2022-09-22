using Finansist.Domain.Commands.Entidade;
using Finansist.Domain.Models.Clients;

namespace Finansist.Domain.Entities
{
    public class Entidade : BaseEntity
    {
        public Entidade()
        {

        }

        public Entidade(CreateEntidadeCommand cmd)
        {
            this.Nome = cmd.Nome;
            this.Descricao = cmd.Descricao;
            this.CEP = cmd.CEP;
            this.Logradouro = cmd.Logradouro;
            this.Bairro = cmd.Bairro;
            this.Complemento = cmd.Complemento;
            this.Localidade = cmd.Localidade;
            this.UF = cmd.UF;
            this.Numero = cmd.Numero;
            this.Ativo = cmd.Ativo;
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
            this.CEP = endereco.CEP;
            this.Logradouro = endereco.Logradouro;
            this.Bairro = endereco.Bairro;
            this.Complemento = endereco.Complemento;
            this.Localidade = endereco.Localidade;
            this.UF = endereco.UF;
            this.Numero = endereco.Numero;
        }
    }
}
