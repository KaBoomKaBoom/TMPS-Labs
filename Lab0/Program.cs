// Create an order
using Lab0.Interfaces;
using Lab0.Models;
using Lab0.Utils;

Order order = new Order
{
    OrderId = "12345",
    CustomerEmail = "customer@example.com"
};

// Using EmailNotificationService to process the order
INotificationService emailService = new EmailNotificationService();
OrderProcessor processor = new OrderProcessor(emailService);

// Process the order
processor.ProcessOrder(order);