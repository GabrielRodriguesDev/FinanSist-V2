using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Finansist.Database.Mapping;
using Finansist.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Finansist.Database.Contexts
{
    public class FinansistContext : DbContext
    {
#nullable disable
        public FinansistContext(DbContextOptions<FinansistContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var typesToMapping =
            (
            from x in Assembly.GetExecutingAssembly().GetTypes()
            where x.IsClass && typeof(IMapping).IsAssignableFrom(x)
            select x
            ).ToList();

            foreach (var mapping in typesToMapping)
            {
                IMapping mappingClass = Activator.CreateInstance(mapping) as IMapping;
                if (mappingClass != null)
                    mappingClass.OnModelCreating(modelBuilder);
            }
        }
        public DbSet<Entidade> Entidade { get; set; }

        public DbSet<ControleSequencia> ControleSequencias { get; set; }
    }
}