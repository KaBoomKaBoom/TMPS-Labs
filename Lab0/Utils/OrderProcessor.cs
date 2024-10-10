using Lab0.Interfaces;
using Lab0.Models;

namespace Lab0.Utils
{
    // Single Responsibility Principle (SRP)
    // This class has only one responsibility, which is managing the order processing logic.
    public class OrderProcessor
    {
        private readonly INotificationService _notificationService;

        // Dependency Inversion Principle (DIP)
        // High-level modules should depend on abstractions, not on details.
        public OrderProcessor(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        public void ProcessOrder(Order order)
        {
            Console.WriteLine("Processing order: " + order.OrderId);

            // Notify the user when the order is processed.
            _notificationService.SendNotification(order);
        }
    }
}