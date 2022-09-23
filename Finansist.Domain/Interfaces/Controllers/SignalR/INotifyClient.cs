

namespace Finansist.Domain.Interfaces.Controllers.SignalR
{
    public interface INotifyClient
    {
        Task SendMessage(string message);
    }
}