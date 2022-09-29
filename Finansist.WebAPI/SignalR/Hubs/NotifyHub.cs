using Finansist.Domain.Interfaces.Controllers.SignalR;
using Microsoft.AspNetCore.SignalR;

namespace Finansist.WebAPI.SignalR.Hubs
{
    public class NotifyHub : Hub<INotifyClient>
    {
        public async Task Notification(object data)
        {
            await Clients.All.SendNotification(data);
        }
    }
}