using Microsoft.AspNet.SignalR.Hosting;
using Newtonsoft.Json.Linq;

namespace Finansist.WebAPI.Helpers
{
    public class CookiesHelper
    {
        public static void SetCookie(HttpResponse response, string token)
        {
            response.Cookies.Append("X-Access-Token", token ?? "", new CookieOptions() { Domain = Environment.GetEnvironmentVariable("DomainCookie"), HttpOnly = true, SameSite = SameSiteMode.Strict, Secure = true, MaxAge = TimeSpan.FromHours(2) });
        }

        public static void ClearCookie(HttpResponse response)
        {
            response.Cookies.Append("X-Access-Token", "false", new CookieOptions() { Domain = Environment.GetEnvironmentVariable("DomainCookie"),  Expires = DateTime.Now.AddDays(-1D) });
        }
    }
}
