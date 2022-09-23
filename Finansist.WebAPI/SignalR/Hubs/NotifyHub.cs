using Finansist.Domain.Interfaces.Controllers.SignalR;
using Microsoft.AspNetCore.SignalR;

namespace Finansist.WebAPI.SignalR.Hubs
{
    public class NotifyHub : Hub<INotifyClient>
    {
        public async Task NewMessage(long username, string message)
        {
            await Clients.All.SendMessage(message);
        }
    }
}