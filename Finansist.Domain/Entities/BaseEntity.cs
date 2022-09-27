namespace Finansist.Domain.Entities
{
    public class BaseEntity
    {
        public BaseEntity()
        {
            this.Id = Guid.NewGuid();
            CriadoEm = DateTime.Now;

        }

        public Guid Id { get; private set; }
        public DateTime? CriadoEm { get; private set; }
        public DateTime? AlteradoEm { get; private set; }


        public void setAlteradoEm()
        {
            this.AlteradoEm = DateTime.Now;
        }

    }
}
