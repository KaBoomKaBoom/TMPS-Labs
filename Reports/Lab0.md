### SOLID Principles Report  
**Author:** Berco Andrei, FAF - 221  

---

### **Objectives:**

- Get familiar with the SOLID principles.
- Choose a specific domain.
- Implement at least 2 SOLID principles for the chosen domain.

---

### **Domain: Order Processing System**

The domain selected for this report is an **Order Processing System**. The system processes customer orders and sends notifications. The implementation follows SOLID principles to ensure flexibility, maintainability, and scalability.

---

### **Used SOLID Principles:**

1. **Single Responsibility Principle (SRP)**  
   Each class is responsible for a single task, avoiding mixed responsibilities.

2. **Dependency Inversion Principle (DIP)**  
   High-level classes rely on abstractions (interfaces) instead of specific implementations.

---

### **Implementation**

#### **Single Responsibility Principle (SRP)**  
The `OrderProcessor` class handles the logic of order processing, while the notification functionality is delegated to a separate `INotificationService`. This division ensures that the responsibility of sending notifications is separated from order processing, adhering to SRP.

#### **Dependency Inversion Principle (DIP)**  
The `OrderProcessor` class depends on the `INotificationService` interface, which allows different implementations (e.g., `EmailNotificationService`, `SmsNotificationService`) to be injected. This provides flexibility in extending or changing notification methods without altering the core logic.

---

### **Snippets from the Code:**

```csharp
// Single Responsibility Principle (SRP)
// This class is only responsible for processing orders.
public class OrderProcessor
{
    private readonly INotificationService _notificationService;

    // Dependency Inversion Principle (DIP)
    // The constructor accepts an interface, enabling flexibility.
    public OrderProcessor(INotificationService notificationService)
    {
        _notificationService = notificationService;
    }

    // Processes the order and triggers a notification.
    public void ProcessOrder(Order order)
    {
        Console.WriteLine("Processing order: " + order.OrderId);
        _notificationService.SendNotification(order); // Delegates notification responsibility.
    }
}

// Interface for Notification Service (DIP)
public interface INotificationService
{
    void SendNotification(Order order);
}

// Implementation of Email Notification (SRP)
public class EmailNotificationService : INotificationService
{
    // Sends an email notification to the customer.
    public void SendNotification(Order order)
    {
        Console.WriteLine($"Email sent to {order.CustomerEmail} for order {order.OrderId}.");
    }
}

// Main method (Program Entry Point)
public class Program
{
    public static void Main(string[] args)
    {
        // Creates a new order and processes it using email notification.
        Order order = new Order { OrderId = "12345", CustomerEmail = "customer@example.com" };
        INotificationService emailService = new EmailNotificationService(); // Injects email service.
        OrderProcessor processor = new OrderProcessor(emailService); // DIP in action.
        processor.ProcessOrder(order); // Processes and sends notification.
    }
}
```

---

### **Important Parts of the Code:**

1. **OrderProcessor Class (SRP)**:  
   This class focuses solely on processing the order. It does not handle notifications directly but delegates that responsibility to the `INotificationService`. This adheres to SRP, ensuring that each class has one reason to change.

2. **INotificationService Interface (DIP)**:  
   The `OrderProcessor` depends on the `INotificationService` abstraction. This means that we can add different types of notification services (e.g., SMS, Push notifications) without modifying the `OrderProcessor`. This follows the Dependency Inversion Principle by ensuring high-level modules depend on abstractions, not implementations.

3. **EmailNotificationService (SRP)**:  
   This class is responsible for sending email notifications. It implements the `INotificationService` interface and is injected into the `OrderProcessor`, allowing flexibility and adherence to SRP.

---

### **Conclusions / Results**

- The **Single Responsibility Principle (SRP)** was successfully implemented by keeping the responsibilities of processing orders and sending notifications in separate classes. This makes the system easier to modify and extend.
  
- The **Dependency Inversion Principle (DIP)** was demonstrated by depending on the `INotificationService` interface rather than specific implementations. This approach ensures flexibility in adding new notification types without changing the core logic.

By following SOLID principles, the system is designed to be maintainable, flexible, and easily extendable with minimal changes to the existing codebase.