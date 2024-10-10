using Lab0.Models;

namespace Lab0.Interfaces
{

    // Interface for notification services
    public interface INotificationService
    {
        void SendNotification(Order order);
    }
}