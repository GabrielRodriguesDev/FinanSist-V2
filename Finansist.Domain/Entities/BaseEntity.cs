namespace Finansist.Domain.Entities
{
    public class BaseEntity
    {
        public BaseEntity()
        {
            this.Id = Guid.NewGuid();
            CriadoEm = DateTime.Now;
            this.CodigoExclusao = 0;
        }

        public Guid Id { get; private set; }
        public DateTime? CriadoEm { get; private set; }
        public DateTime? AlteradoEm { get; private set; }
        public DateTime? ExcluidoEm { get; private set; }
        public int CodigoExclusao { get; private set; }

    }
}
