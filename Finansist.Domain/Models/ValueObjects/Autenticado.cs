

using Finansist.Domain.Entities;

namespace Finansist.Domain.Models.ValueObjects
{
    public class Autenticado
    {
        public Autenticado(Usuario usuario)
        {
          
        }

        public String? Token { get; set; }

    }
}