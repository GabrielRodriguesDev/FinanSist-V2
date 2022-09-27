
using Finansist.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Finansist.Database.Mapping
{
    public class UsuarioMapping : BaseMapping<Usuario>, IMapping
    {
        public override void OnModelCreating(ModelBuilder modelBuilder)
        {
            {
                base.OnModelCreating(modelBuilder);

                entity.Property(a => a.Nome).HasColumnType("varchar(120)");
                entity.Property(a => a.Email).HasColumnType("varchar(120)");
                entity.HasIndex(a => a.Email).HasDatabaseName("unq1_Usuario").IsUnique();
                entity.Property(a => a.Senha).HasColumnType("varchar(30)");
                entity.Property(a => a.Telefone).HasColumnType("varchar(15)");

                #region Comments
                entity.HasComment("Tabela responsável pelos registros de entidade.");
                entity.Property(t => t.Nome).HasComment("Nome.");
                entity.Property(t => t.Email).HasComment("E-mail.");
                entity.Property(t => t.Senha).HasComment("Senha.");
                entity.Property(t => t.Perfil).HasComment("Perfil do Usuário. { 1 -> Administrador, 2 -> Cliente }.");
                entity.Property(t => t.Ativo).HasComment("Define de o registro está ativo.");
                #endregion
            }
        }
    }
}