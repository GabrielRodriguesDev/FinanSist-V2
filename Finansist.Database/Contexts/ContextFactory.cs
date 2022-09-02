using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Finansist.Database.Contexts
{
    public class ContextFactory : IDesignTimeDbContextFactory<FinansistContext>
    {
        public FinansistContext CreateDbContext(string[] args)
        {
            var connectionString = "Server=localhost;Port=3306;Database=Finansist;Uid=root;Pwd=fx870";

            var optionsBuilder = new DbContextOptionsBuilder<FinansistContext>();
            optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)).LogTo(Console.Write);
            return new FinansistContext(optionsBuilder.Options);
        }
    }
}
