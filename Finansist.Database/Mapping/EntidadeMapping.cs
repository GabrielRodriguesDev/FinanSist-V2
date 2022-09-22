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
                entity.Property(a => a.CEP).HasColumnType("varchar(8)");
                entity.Property(a => a.Logradouro).HasColumnType("varchar(120)");
                entity.Property(a => a.Bairro).HasColumnType("varchar(120)");
                entity.Property(a => a.Complemento).HasColumnType("varchar(120)");
                entity.Property(a => a.UF).HasColumnType("varchar(2)");


                #region Comments
                entity.HasComment("Tabela responsável pelos registros de entidade.");
                entity.Property(t => t.Nome).HasComment("Nome.");
                entity.Property(t => t.Descricao).HasComment("Descrição.");
                entity.Property(t => t.CodigoInterno).HasComment("Código interno (sequencial).");
                entity.Property(t => t.CEP).HasComment("CEP.");
                entity.Property(t => t.Logradouro).HasComment("Logradouro.");
                entity.Property(t => t.Bairro).HasComment("Bairro.");
                entity.Property(t => t.Complemento).HasComment("Complemento.");
                entity.Property(t => t.UF).HasComment("UF.");
                entity.Property(t => t.Numero).HasComment("Número do endereço.");
                entity.Property(t => t.Ativo).HasComment("Define de o registro está ativo.");
                #endregion
            }
        }
    }
}