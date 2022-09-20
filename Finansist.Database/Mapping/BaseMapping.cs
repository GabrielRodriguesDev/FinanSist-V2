using Finansist.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finansist.Database.Mapping
{
    public abstract class BaseMapping<TEntity> where TEntity : BaseEntity
    {
#nullable disable
        protected EntityTypeBuilder<TEntity> entity;
        public virtual void OnModelCreating(ModelBuilder modelBuilder)
        {
            this.entity = modelBuilder.Entity<TEntity>();
            entity.ToTable(typeof(TEntity).Name).HasCharSet("utf8");
            entity.HasKey(t => t.Id);
            entity.Property(a => a.Id).HasColumnType("char(36)").IsRequired();

            #region  Comments
            entity.Property(t => t.Id).HasComment("Identificador do registro.");
            entity.Property(t => t.CriadoEm).HasComment("Data e hora de criação do registro.");
            entity.Property(t => t.AlteradoEm).HasComment("Data e hora da última alteração do registro.");
            entity.Property(t => t.ExcluidoEm).HasComment("Data e hora da exclusão lógica do registro.");
            #endregion
        }
    }
}
