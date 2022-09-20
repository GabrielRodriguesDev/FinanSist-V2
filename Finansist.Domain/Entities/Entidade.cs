namespace Finansist.Domain.Entities
{
    public class Entidade : BaseEntity
    {
        public Entidade()
        {

        }

        public String Nome { get; private set; } = null!;

        public String Descricao { get; private set; } = null!;

        public int CodigoInterno { get; private set; }

        public bool Ativo { get; private set; }

    }
}
