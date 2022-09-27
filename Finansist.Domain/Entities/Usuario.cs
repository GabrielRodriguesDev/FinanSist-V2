
using Finansist.Domain.Commands.Usuario;
using Finansist.Domain.Helpers;

namespace Finansist.Domain.Entities
{
    public class Usuario : BaseEntity
    {
        public Usuario()
        {

        }

        public Usuario(CreateUsuarioCommand createCommand)
        {
            this.Nome = createCommand.Nome!;
            this.Email = createCommand.Email!;
            this.Telefone = createCommand.Telefone;
            this.Perfil = createCommand.Tipo!.Value;
            this.Ativo = createCommand.Ativo;
            this.Senha = CriptoHelper.CreateRandomPassword();
            this.ExigirNovaSenha = true;
        }

        public String Nome { get; private set; } = null!;
        public String Email { get; private set; } = null!;
        public String Senha { get; private set; } = null!;
        public String? Telefone { get; private set; } = null!;
        public PerfilUsuarioEnum Perfil { get; private set; }
        public bool Ativo { get; private set; }
        public bool ExigirNovaSenha { get; private set; }


    }
}