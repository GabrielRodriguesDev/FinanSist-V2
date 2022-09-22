using Finansist.CrossCutting.Clients.ViaCEP;
using Finansist.Domain.Interfaces.CrossCutting.Interfaces.Clients;
using Microsoft.Extensions.DependencyInjection;

namespace Finansist.CrossCutting
{
    public class ConfigureClient
    {
        public static void ConfigureDI(IServiceCollection services)
        {
            services.AddScoped<IViaCEPClient, ViaCEPClient>();
        }
    }
}
