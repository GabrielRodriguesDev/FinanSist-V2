using Finansist.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Finansist.Database.Mapping
{
    public class EntidadeMapping : BaseMapping<Entidade>, IMapping
    {
        public override void OnModelCreating(ModelBuilder modelBuilder)
        {
            {
                base.OnModelCreating(modelBuilder);

                entity.Property(a => a.Nome).HasColumnType("varchar(120)");
                entity.Property(a => a.Descricao).HasColumnType("varchar(150)");
                entity.HasIndex(i => i.CodigoInterno).HasDatabaseName("unq1_Entidade").IsUnique();

                #region Comments
                entity.HasComment("Tabela responsável pelos registros de entidade.");
                entity.Property(t => t.Nome).HasComment("Nome da Entidade.");
                entity.Property(t => t.Descricao).HasComment("Descrição da Entidade.");
                entity.Property(t => t.CodigoInterno).HasComment("Código interno (sequencial) da Entidade.");
                #endregion
            }
        }
    }
}