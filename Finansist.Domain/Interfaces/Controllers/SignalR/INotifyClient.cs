

namespace Finansist.Domain.Interfaces.Controllers.SignalR
{
    public interface INotifyClient
    {
        Task SendNotification(Object Data);

        // Task<String> GetConnectionId();
    }
}