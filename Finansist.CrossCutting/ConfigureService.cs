using Finansist.Domain.Interfaces.Domain.Services;
using Finansist.Domain.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Finansist.CrossCutting
{
    public class ConfigureService
    {
        public static void ConfigureDI(IServiceCollection services)
        {
            services.AddScoped<IEntidadeService, EntidadeService>();
        }
    }
}