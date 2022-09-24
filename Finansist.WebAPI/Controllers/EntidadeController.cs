using Finansist.Domain.Commands.Entidade;
using Finansist.Domain.Interfaces.Controllers.SignalR;
using Finansist.Domain.Interfaces.Domain.Services;
using Finansist.WebAPI.SignalR.Hubs;
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
        public async Task<IActionResult> Create([FromServices] IEntidadeService services, [FromBody] CreateEntidadeCommand createCommand)
        {
            var tsc = new TaskCompletionSource<IActionResult>();
            var result = services.Create(createCommand);
            // var genericResult = result.Result.Data!.GetType();
            // var nome = genericResult.GetProperty("Nome")!.GetValue(genericResult.GetProperty("Nome"));

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
    }
}