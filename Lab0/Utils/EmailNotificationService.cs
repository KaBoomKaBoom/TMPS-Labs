// Concrete implementation of notification service - Email
using Lab0.Interfaces;
using Lab0.Models;

namespace Lab0.Utils
{
    public class EmailNotificationService : INotificationService
    {
        public void SendNotification(Order order)
        {
            Console.WriteLine($"Email sent to {order.CustomerEmail} for order {order.OrderId}.");
        }
    }
}