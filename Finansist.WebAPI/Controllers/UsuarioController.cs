using Finansist.Domain.Commands.Usuario;
using Finansist.Domain.Interfaces.Domain.Services;
using Finansist.Infrastructure.Errors;
using Finansist.WebAPI.Helpers;
using Finansist.WebAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace Finansist.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Create([FromServices] IUsuarioService services, [FromBody] CreateUsuarioCommand createCommand)
        {
            var tsc = new TaskCompletionSource<IActionResult>();

            ErrorCatalogHelper.SettingCatalogedError(HttpContext, ErrorCatalog.UsuarioCreate);

            var result = services.Create(createCommand);

            var token = TokenService.GenerateJwtToken(HttpContext, Guid.Parse("c48df834-7d19-4e3a-8cb3-ecf0571f09a0"), "Gabriel Silva Rodrigues Mota", "gabriel@onsist.com.br");

            tsc.SetResult(new JsonResult(result)
            {
                StatusCode = 200
            });
            return await tsc.Task;
        }
    }
}