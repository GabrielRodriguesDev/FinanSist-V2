using Finansist.Domain.Commands.Entidade;
using Finansist.Domain.Commands.Result;
using Finansist.Domain.Interfaces.Controllers.SignalR;
using Finansist.Domain.Interfaces.Database.Repositories;
using Finansist.Domain.Interfaces.Services;
using Finansist.Infrastructure.Errors;
using Finansist.WebAPI.Helpers;
using Finansist.WebAPI.SignalR.Hubs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace Finansist.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EntidadeController : ControllerBase
    {

        private IHubContext<NotifyHub, INotifyClient> _hubContext;
        public EntidadeController(IHubContext<NotifyHub, INotifyClient> hubContext)
        {
            _hubContext = hubContext;
        }
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create([FromServices] IEntidadeService services, [FromBody] CreateEntidadeCommand createCommand)
        {
            var tsc = new TaskCompletionSource<IActionResult>();

            ErrorCatalogHelper.SettingCatalogedError(HttpContext, ErrorCatalog.EntidadeCreate);

            var result = services.Create(createCommand);

            if (result.Result.Sucess)
                await _hubContext.Clients.All.SendNotification(new
                {
                    Nome = "Gabriel",
                    Idade = 20,
                    Sonho = "Estabilidade"
                });

            tsc.SetResult(new JsonResult(result.Result)
            {
                StatusCode = 200
            });
            return await tsc.Task;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get([FromServices] IEntidadeRepository services, [FromRoute] Guid id)
        {
            var tsc = new TaskCompletionSource<IActionResult>();

            ErrorCatalogHelper.SettingCatalogedError(HttpContext, ErrorCatalog.EntidadeCreate);

            dynamic? result = services.Get(id);

            if (result is null) result = new GenericCommandResult(false, "Entidade não localizada.");

            tsc.SetResult(new JsonResult(result)
            {
                StatusCode = 200
            });
            return await tsc.Task;
        }

    }
}