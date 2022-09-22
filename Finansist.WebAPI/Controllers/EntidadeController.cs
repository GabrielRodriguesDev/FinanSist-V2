using Finansist.Domain.Commands.Entidade;
using Finansist.Domain.Interfaces.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace Finansist.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EntidadeController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Create([FromServices] IEntidadeService services, [FromBody] CreateEntidadeCommand createCommand)
        {
            var tsc = new TaskCompletionSource<IActionResult>();
            var result = services.Create(createCommand);
            tsc.SetResult(new JsonResult(result)
            {
                StatusCode = 200
            });
            return await tsc.Task;
        }
    }
}