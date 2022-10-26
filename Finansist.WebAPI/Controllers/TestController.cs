using Finansist.Domain.Commands.Test;
using Finansist.Domain.Commands.Usuario;
using Finansist.Domain.Interfaces.Services;
using Finansist.Infrastructure.Errors;
using Finansist.WebAPI.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace Finansist.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Create([FromForm] CreateTestCommand command)
        {
            var tsc = new TaskCompletionSource<IActionResult>();
            //ErrorCatalogHelper.SettingCatalogedError(HttpContext, ErrorCatalog.UsuarioCreate);
            
            tsc.SetResult(new JsonResult(command)
            {
                StatusCode = 200
            });
            return await tsc.Task;
        }
    }
}