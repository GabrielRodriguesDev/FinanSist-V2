

using Finansist.Domain.Entities;

namespace Finansist.Domain.Models.ValueObjects
{
    public class Autenticado
    {
        public Autenticado(Usuario usuario)
        {
            this.Id = usuario.Id;
            this.Nome = usuario.Nome;
            this.Email = usuario.Email;
            this.Perfil = usuario.Perfil;
        }

        public Guid Id { get; set; }
        public String Nome { get; set; } = null!;
        public String Email { get; set; } = null!;
        public PerfilUsuarioEnum Perfil { get; set; }
        public String? Token { get; set; }

    }
}