using Finansist.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Finansist.Database.Mapping
{
    public class ControleSequenciaMapping : BaseMapping<ControleSequencia>, IMapping
    {
        public override void OnModelCreating(ModelBuilder modelBuilder)
        {
            {
                base.OnModelCreating(modelBuilder);

                entity.Property(a => a.Nome).HasColumnType("varchar(150)");
                entity.HasIndex(a => a.Nome).HasDatabaseName("unq1_Entidade").IsUnique();

                #region Comments
                entity.HasComment("Tabela responsável pelo controle de sequencia.");
                entity.Property(t => t.Nome).HasComment("Nome das tabelas.");
                entity.Property(t => t.Numero).HasComment("Número sequencial.");
                #endregion
            }
        }
    }
}