### Behavioral Design Patterns  
**Author:** Berco Andrei, FAF - 221  

---

### **Objectives:**

- Study and understand the Behavioral Design Patterns.
- As a continuation of the previous laboratory work, think about what communication between software entities might be involed in your system.
- Implement some additional functionalities using behavioral design patterns.

---

### **Domain: eCommerce System**

The domain selected for this report is an **eCommerce System**. The system handles product management, order creation, and payment processing, allowing customers to browse products, add them to a cart, and complete purchases. The implementation leverages creational design patterns to ensure flexibility, scalability, and ease of future enhancements.

--- 

### **Used Patterns**

In this project, I implemented several **Behavioral Design Patterns** to help to perform the tasks involved in the system:

1. **Chain of Responsibility Pattern**  
    Chain of Responsibility is a behavioral design pattern that lets you pass requests along a chain of handlers. Upon receiving a request, each handler decides either to process the request or to pass it to the next handler in the chain.

    ![Alt text](/Images/Chain.png)


2. **Strategy Pattern**  
    Strategy is a behavioral design pattern that lets you define a family of algorithms, put each of them into a separate class, and make their objects interchangeable.

    ![Alt text](/Images/Startegy.png)


3. **Observer Pattern**  
    Observer is a behavioral design pattern that lets you define a subscription mechanism to notify multiple objects about any events that happen to the object they’re observing.

    ![Alt text](/Images/Observer.png)

---

### **Implementation of Behavioral Design Patterns**

In this project, I implemented the **Chain of Responsibility**, **Strategy**, and **Observer** patterns to handle various aspects of the eCommerce system, like order placement system, observe shipment details of an order and discount application to products in a shopping cart. Below are the implementation details with code snippets:

---

#### **1. Chain of Responsibility Pattern**

The **Chain of Responsibility Pattern** was used in implementation of order placing system. The handers used within this pattern were to verify different aspects of the order: emptiness of shopping cart, availabilty of product, shipment and payement details. If each of these aspect is good, then the order is precessed. If one of these steps fails, it is thrown an error.

**Code Snippet:**

Lab2/OrderSystem/IOrderValidationHandler.cs
```csharp
    public interface IOrderValidationHandler
    {
        void SetNext(IOrderValidationHandler nextHandler);
        void Handle(OrderContext context);
    }
```

This is a public interface with 2 deffined methods for setting next handler `SetNext` and handling the given context `Handle`.

Next, is defined a public abstract class `OrderValidationHandler` which implements the above interface.

After this, I have 4 handlers which implements the base handler `OrderValidationHandler`. This handler are for checking the shopping cart, product stock, validity of shipment and payement information. Below is one of them:

Lab2/OrderSystem/Handlers/DeliveryInfoHandler.cs
```csharp
    public class DeliveryInfoHandler : OrderValidationHandler
    {
        public override void Handle(OrderContext context)
        {
            if (string.IsNullOrWhiteSpace(context.DeliveryInformation))
            {
                throw new Exception("Delivery information is missing or invalid.");
            }

            NextHandler?.Handle(context);
        }
    }
```

Here is defined `DeliveryInfoHandler` which implements the base handler. The `Handle` method is for checking if there exists any information about the delivery, like address. If there is none, there is thrown an error. If everythin is ok, the next handler is handled.

After setting up all handlers, there is defined a public class `OrderService` where this chain is assembled toproces the order:
```csharp
    cartHandler.SetNext(stockHandler);
    stockHandler.SetNext(deliveryHandler);
    deliveryHandler.SetNext(paymentHandler);
```
 
**Usage Example:**

Lab3/Program.cs
```csharp
var orderContext = new OrderContext(
    shoppingCart,
    "123 Main Street, Springfield",
    "Test payment details"
);

var orderService = new OrderService();
orderService.PlaceOrder(orderContext);
```
First of all we need a shopping cart and we suppose it is not empty. Next, we define an `orderContext`, where as arguments are passed the shopping cart, delivery information and payement details. Next, we create an instanse of `OrderService` class and we `PlaceOrder`. It will start to process the chain, and if everything is good, there will be displayed the message "Order processed succesfully".

#### **2. Strategy Pattern**

The **Strategy Pattern** was used to create multiple types of discounts as separate classes and apply them independently, based on clients needs.

**Code Snippet:**

Lab3/DiscountSystem/IDiscountStrategy.cs
```csharp 
    public interface IDiscountStrategy
    {
        decimal ApplyDiscount(decimal totalAmount);
    }
```
First, we define a public interface `IDiscountStrategy` with a method to apply the requiered discount and that returns a decimal value.

Next step is to define the discount strategies that will be next used in the project. In my case, I have 4 discount strategies: no discount, seasonal discount, new member discount and coupon discount. Below will be an example of a discount implementation:

Lab3/DiscountSystem/SeasonalDiscount.cs
```csharp
public class SeasonalDiscount : IDiscountStrategy
    {
        private readonly decimal _percentage;

        public SeasonalDiscount(decimal percentage) => _percentage = percentage;

        public decimal ApplyDiscount(decimal totalAmount) => totalAmount - (totalAmount * _percentage / 100);
    }
```
Here is defined a public class `SeasonalDiscount` which implemets the interface avove. Here is declared a private field `_percentage` which holds the discount value. Next, is implemented the method `ApplyDiscount` defined in interface. It takes as argument the total amount of the price of shopping cart, and returns the total value of the cart after appling the discount.

Next, in the `ShoppingCart` was added a private field for discount strategy:

```csharp
private IDiscountStrategy _discountStrategy;
```

Also in `ShoppingCart` was added a method to calculate the total value of the shopping cart after applying the discount strategy:

```csharp
    public decimal CalculateTotal()
    {
        decimal totalAmount = Products.Sum(p => p.Price);
        return _discountStrategy.ApplyDiscount(totalAmount);
    }
```
Here, first is calculated total value of the shopping card, saved in the variable `totalAmount`. After that, the method returns `totalAmount` after applying the discount strategy.

**Usage Example:**

Lab3/Program.cs
```csharp
// Seasonal discount
shoppingCart.SetDiscountStrategy(new SeasonalDiscount(15)); // 15% seasonal discount
Console.WriteLine($"Total after seasonal discount: {shoppingCart.CalculateTotal()}");
```
First, we need an instance of shopping cart with some products in it. Next, using the method `SetDiscountStrategy` from `shoppingCart` (in our case seasonal discount). The next line just prints the total value of `shoppingCart` after applying the discount.

#### **3. Observer Pattern**

The **Observer Pattern** was used to track the changes in shipment staus of an order, like processing, shipped or delivers. After this status is changed, a notification message is send to the attached observers to the subject. 

**Code Snippet:**

Lab2/ObserverSystem/ISubject.cs
```csharp
    public interface ISubject
    {
        void Attach(IObserver observer);
        void Detach(IObserver observer);
        void Notify();
    }

```
Here is declared a public interface `ISubject` containing 3 methods, to attach an observer to a subject, to detach it and to notify them about any changes.

Next, I defined a class `Order` which implements the interface above. This represent an subject for observers to observe. Below are the implemented methods from the interface `ISubject`.
```csharp
        public void Attach(IObserver observer)
        {
            _observers.Add(observer);
        }

        public void Detach(IObserver observer)
        {
            _observers.Remove(observer);
        }

        public void Notify()
        {
            foreach (var observer in _observers)
            {
                observer.Update(OrderId, _status);
            }
        }
```
Method `Attach` takes as an argument an object of type `IObserver`. The functionality of this method is to add the given observer to the list of observers.

Method `Detach` s similar to the above one. The argument also is an observer. Its functionality is to remove the observer from the list of active observers.

Method `Notify` traverse the list of active observers and updates the status of an order and notifies the observer on updated status through a message to the console.

Next, in my project, are defined 2 types of observers: admin and customer. Below is the implementation of the admin observer:

```csharp
    public class AdminObserver : IObserver
    {
        public void Update(string orderId, string status)
        {
            Console.WriteLine($"[Admin Notification] Order {orderId} status updated to: {status}");
        }
    }
```

`AdminObserver` is a class that implements the interface `IObserver`. It has a method `Update`, which prints to console a notification when the status of an order is updated.

**Usage Example:**

Lab3/Program.cs
```csharp
var order = new Order("ORD123", "Pending");

var adminObserver = new AdminObserver();
var customerObserver = new CustomerObserver("John Doe");

order.Attach(adminObserver);
order.Attach(customerObserver);

Console.WriteLine("Updating order status to 'Processing'...");
order.Status = "Processing";
```
First, we create an instance `order` of type `Order`.

After this, we create 2 observers of types `AdminObserver` and `CustomerObserver` which will observe the changes in order's status.

Next, we use method `Atach`, to attach these observers to the subject, in our case `order`.

Next, we update the order status to `Processing`. An information message will be printed to console about the changes in status:

```
[Admin Notification] Order ORD123 status updated to: Processing
[Customer Notification] Dear John Doe, your order ORD123 is now: Processing
```
 
### **Conclusion**

In this project, I successfully implemented several **Behavioral Design Patterns** in an eCommerce domain. The **Chain of Responsabilitie  Pattern** allowed us easily to process an order by validating multiple aspects in order details, like availability or shipment details, and catching any errors. The **Strategy Pattern** helped us to declare multiple independent discount startegies and allowed client to choose which one to use. The last pattern used was **Observer**, which allowed us to develop an observing system that looks into oder status, like processing or shipped, and notify the client or admin about its changes.

