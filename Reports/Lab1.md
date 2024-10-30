### Creational Design Patterns  
**Author:** Berco Andrei, FAF - 221  

---

### **Objectives:**

- Study and understand the Creational Design Patterns.
- Choose a domain, define its main classes/models/entities and choose the appropriate instantiation mechanisms.
- Use some creational design patterns for object instantiation in a sample project.

---

### **Domain: eCommerce System**

The domain selected for this report is an **eCommerce System**. The system handles product management, order creation, and payment processing, allowing customers to browse products, add them to a cart, and complete purchases. The implementation leverages creational design patterns to ensure flexibility, scalability, and ease of future enhancements.

--- 

### **Used Patterns**

In this project, I implemented several **Creational Design Patterns** to optimize object creation and improve system flexibility:

1. **Builder Pattern**  
   The Builder Pattern allows the step-by-step construction of complex objects. This pattern is particularly useful when creating objects with many optional fields or configurations. It separates the construction process from the object's representation, offering flexibility in how the final product is created.

2. **Singleton Pattern**  
   The Singleton Pattern ensures that a class has only one instance while providing global access to that instance. It is often used for managing shared resources like a shopping cart or database connection, where having multiple instances could lead to inconsistent states.

3. **Factory Method Pattern**  
   The Factory Method Pattern defines an interface for creating objects but allows subclasses to alter the type of objects that will be created. It promotes loose coupling by delegating the responsibility of object instantiation to subclasses, ensuring that the code is open for extension but closed for modification.

---

### **Implementation of Creational Design Patterns**

In this project, I implemented the **Builder**, **Singleton**, and **Factory Method** patterns to handle various aspects of the eCommerce system such as product configuration, shopping cart management, and payment processing. Below are the implementation details with code snippets:

---

#### **1. Builder Pattern**

The **Builder Pattern** was used to create products in a flexible manner. I defined an `IProductBuilder` interface that allows step-by-step configuration of a product and implemented a concrete `ProductBuilder` class.

**Code Snippet:**

```csharp
public interface IProductBuilder
{
    void SetProductName(string name);
    void SetPrice(decimal price);
    void SetCategory(string category);
    void SetDescription(string description);
    void SetSKU(string sku);
    void SetStock(int stock);
}

public class ProductBuilder : IProductBuilder
{
    private string _name;
    private decimal _price;
    private string _category;
    private string _description;
    private string _sku;
    private int _stock;

    public void SetProductName(string name) { _name = name; }
    public void SetPrice(decimal price) { _price = price; }
    public void SetCategory(string category) { _category = category; }
    public void SetDescription(string description) { _description = description; }
    public void SetSKU(string sku) { _sku = sku; }
    public void SetStock(int stock) { _stock = stock; }

    public Product Build()
    {
        return new Product(_name, _price, _category, _description, _sku, _stock);
    }
}
```

This allows us to construct products in a flexible and controlled manner.

**Usage Example:**

```csharp
IProductBuilder builder = new ProductBuilder();
builder.SetProductName("Laptop");
builder.SetPrice(1000);
builder.SetCategory("Electronics");
builder.SetDescription("High-end laptop");
builder.SetSKU("LAPTOP-001");
builder.SetStock(10);
Product laptop = builder.Build();
```

---

#### **2. Singleton Pattern**

The **Singleton Pattern** was applied to the `ShoppingCart` class to ensure that only one instance of the cart exists for a given session.

**Code Snippet:**

```csharp
public interface IShoppingCart
{
    void AddProduct(IProduct product);
    List<IProduct> GetProducts();
}

public class ShoppingCart : IShoppingCart
{
    private static ShoppingCart _instance;
    private List<IProduct> _products = new List<IProduct>();

    private ShoppingCart() { }

    public static ShoppingCart Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new ShoppingCart();
            }
            return _instance;
        }
    }

    public void AddProduct(IProduct product)
    {
        _products.Add(product);
    }

    public List<IProduct> GetProducts()
    {
        return _products;
    }
}
```

The singleton ensures that a single, shared instance of `ShoppingCart` is used throughout the system.

**Usage Example:**

```csharp
IShoppingCart cart = ShoppingCart.Instance;
cart.AddProduct(new Product("Laptop", 1000));
List<IProduct> products = cart.GetProducts();
```

---

#### **3. Factory Method Pattern**

The **Factory Method Pattern** was employed to handle the creation of payment methods. This pattern allows the system to instantiate different payment methods (e.g., Credit Card, PayPal) dynamically based on user input.

**Code Snippet:**

```csharp
public interface IPayment
{
    void ProcessPayment();
}

public abstract class Payment : IPayment
{
    public abstract void ProcessPayment();
}

public class CreditCardPayment : Payment
{
    public override void ProcessPayment()
    {
        Console.WriteLine("Processing credit card payment...");
    }
}

public class PayPalPayment : Payment
{
    public override void ProcessPayment()
    {
        Console.WriteLine("Processing PayPal payment...");
    }
}

public class PaymentFactory
{
    public static IPayment CreatePayment(string type)
    {
        switch (type)
        {
            case "CreditCard":
                return new CreditCardPayment();
            case "PayPal":
                return new PayPalPayment();
            default:
                throw new Exception("Payment method not supported.");
        }
    }
}
```

The factory allows us to create different payment methods based on user input, making the code more modular and maintainable.

**Usage Example:**

```csharp
IPayment payment = PaymentFactory.CreatePayment("PayPal");
payment.ProcessPayment();
```

---

### **Summary of Implementation**

By using the **Builder Pattern**, I were able to construct products flexibly with various configurations. The **Singleton Pattern** ensured the proper management of shared resources like the shopping cart, while the **Factory Method Pattern** facilitated the creation of different payment methods, adhering to the **open/closed principle**. These patterns collectively enhanced the system’s scalability, maintainability, and flexibility.


### **Conclusion**

In this project, I successfully implemented several **Creational Design Patterns** in an eCommerce domain, focusing on efficient and flexible object creation. The **Builder Pattern** allowed us to create complex product objects step by step, while the **Singleton Pattern** ensured the proper management of shared instances like the shopping cart. Additionally, the **Factory Method Pattern** provided a modular approach for creating different payment methods. These patterns not only improved the flexibility and scalability of the system but also adhered to SOLID principles, making the codebase easier to maintain and extend in the future. By leveraging these patterns, I achieved a more robust and adaptable solution for our eCommerce platform. 

