namespace Finansist.Domain.Entities
{
    public class Entidade : BaseEntity
    {
        public String Nome { get; private set; } = null!;

        public String Descricao { get; private set; } = null!;

        public bool Ativo { get; private set; }
    }
}
