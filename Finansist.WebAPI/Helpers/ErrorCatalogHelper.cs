using Finansist.Domain.Interfaces.Infrastructure;


namespace Finansist.WebAPI.Helpers
{
    public class ErrorCatalogHelper
    {
        public static void SettingCatalogedError(HttpContext httpContext, String catalogedErrorCode)
        {
            IErrorManager service = httpContext.RequestServices.GetRequiredService<IErrorManager>();
            service.setCatalogedError(catalogedErrorCode);
        }
    }
}