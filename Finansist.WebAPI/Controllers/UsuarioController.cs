using Finansist.Domain.Commands.Usuario;
using Finansist.Domain.Interfaces.Services;
using Finansist.Infrastructure.Errors;
using Finansist.WebAPI.Helpers;
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
            tsc.SetResult(new JsonResult(result)
            {
                StatusCode = 200
            });
            return await tsc.Task;
        }
    }
}