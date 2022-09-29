using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Finansist.Database.Contexts
{
    public class ContextFactory : IDesignTimeDbContextFactory<FinansistContext>
    {
        public FinansistContext CreateDbContext(string[] args)
        {
            //var connectionString = "Server=localhost;Port=3306;Database=finansist;Uid=root;Pwd=fx870";
            var connectionString = "Server=gabriel-database-do-user-12271655-0.b.db.ondigitalocean.com;Port=25060;Database=finansist;Uid=doadmin;Pwd=AVNS_mR1t_CCRXMAg_x4Qlzk";

            var optionsBuilder = new DbContextOptionsBuilder<FinansistContext>();
            optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)).LogTo(Console.Write);
            return new FinansistContext(optionsBuilder.Options);
        }
    }
}
