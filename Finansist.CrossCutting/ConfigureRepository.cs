using Finansist.Database.Contexts;
using Finansist.Database.Helpers;
using Finansist.Database.Repositories;
using Finansist.Domain.Interfaces.Database.Helpers;
using Finansist.Domain.Interfaces.Database.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Finansist.CrossCutting
{
    public class ConfigureRepository
    {
        public static void ConfigureDI(IServiceCollection services)
        {
            var connection = "Server=localhost;Port=3306;Database=finansist;Uid=root;Pwd=fx870";

            #region Context
            services.AddDbContext<FinansistContext>(options => options.UseMySql(connection, ServerVersion.AutoDetect(connection)));
            //services.AddDbContext<FinansistContext>(options => options.UseMySql(connection, ServerVersion.AutoDetect(connection)).LogTo(Console.Write));
            #endregion

            #region Repository
            services.AddScoped<FinansistContext, FinansistContext>();
            services.AddScoped<IEntidadeRepository, EntidadeRepository>();
            #endregion

            #region Helpers
            services.AddScoped<IControleSequenciaHelper, ControleSequenciaHelper>();
            #endregion
        }
    }
}
