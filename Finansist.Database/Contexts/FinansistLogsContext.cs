
using Microsoft.EntityFrameworkCore;

namespace Finansist.Database.Contexts
{
    public class FinansistLogsContext : DbContext
    {
        public FinansistLogsContext(DbContextOptions<FinansistLogsContext> options) : base(options)
        {

        }
    }
}