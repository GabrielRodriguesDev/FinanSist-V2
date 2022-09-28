using Finansist.Domain.Commands.Autentica;
using Finansist.Domain.Interfaces.Services;
using Finansist.Infrastructure.Errors;
using Finansist.WebAPI.Helpers;
using Finansist.WebAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace Finansist.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AutenticaController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Login([FromServices] IAutenticaService services, [FromBody] LoginCommand loginCommand)
        {
            var tsc = new TaskCompletionSource<IActionResult>();
            ErrorCatalogHelper.SettingCatalogedError(HttpContext, ErrorCatalog.AutenticaLogin);
            
            CookiesHelper.ClearCookie(Response);

            var result = services.Login(loginCommand);
            if (result.Sucess && result.Autenticado != null)
            {
                var token = TokenService.GenerateJwtToken(HttpContext, result.Autenticado);
                result.Autenticado.Token = token;

                CookiesHelper.SetCookie(Response, token);
            }
            tsc.SetResult(new JsonResult(result)
            {
                StatusCode = 200
            });
            return await tsc.Task;
        }
    }
}