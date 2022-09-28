using Finansist.Domain.Interfaces.Services;
using Finansist.Domain.Interfaces.Infrastructure;
using Finansist.Domain.Services;
using Finansist.Infrastructure.Errors;
using Microsoft.Extensions.DependencyInjection;

namespace Finansist.CrossCutting
{
    public class ConfigureService
    {
        public static void ConfigureDI(IServiceCollection services)
        {
            services.AddScoped<IEntidadeService, EntidadeService>();
            services.AddScoped<IUsuarioService, UsuarioService>();
            services.AddScoped<IAutenticaService, AutenticaService>();

            #region  Infrastructure
            services.AddScoped<IErrorManager, ErrorManager>();
            #endregion
        }
    }
}