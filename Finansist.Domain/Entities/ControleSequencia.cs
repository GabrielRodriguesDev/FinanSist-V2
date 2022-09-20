namespace Finansist.Domain.Entities
{
    public class ControleSequencia : BaseEntity
    {
        public ControleSequencia(string nome)
        {
            this.Nome = nome.ToUpper();
            this.Numero = 1;
        }
        public String Nome { get; private set; } = null!;
        public int Numero { get; private set; }

        public void setProximoNumero()
        {
            this.Numero++;
        }
    }
}