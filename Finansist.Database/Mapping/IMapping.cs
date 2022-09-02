using Microsoft.EntityFrameworkCore;

namespace Finansist.Database.Mapping
{
    public interface IMapping
    {
        void OnModelCreating(ModelBuilder modelBuilder);

    }
}
