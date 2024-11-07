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
    Builder is a creational design pattern that lets you construct complex objects step by step. The pattern
    allows you to produce different types and representations of an object using the same construction code.

    ![Alt text](/Images/BuilderDiagram.png)


2. **Singleton Pattern**  
    Singleton is a creational design pattern that lets you ensure that a class has only one instance, while
    providing a global access point to this instance.

    ![Alt text](/Images/SingletonDiagram.png)


3. **Factory Method Pattern**  
    Factory Method is a creational design pattern that provides an interface for creating objects in a
    superclass, but allows subclasses to alter the type of objects that will be created.

    ![Alt text](/Images/FactoryMthodDiagram.png)

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

In the interfac `IProductBuilder` are defined abstract methods to set different propreties of a product. Each method takes its own parameter. Some product's propreties that may be set are `Name`, `Price`, `Category` etc.

Next, it is defined a class `ProductBuilder`, which is a concrete implementation of the interface above. First, it has privat fields of product propreties. After that follow the concrete implementationn of interface's methods for setting the propreties defined above. Also, a final method is `Build`, which returns an object of `Product` with set characteristics.

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
In this usage example, first we create an instance of `ProductBuilder`. After that, we set some custom characteeristics to our product. Final step is building an object of type `Product`, in this case a laptop.

Also, in this laboratory work is implemented a `Director` class, where are defined some default products. Below is the implementation of this.

```csharp
public class ProductDirector
    {
        private readonly IProductBuilder _builder;

        public ProductDirector(IProductBuilder builder)
        {
            _builder = builder;
        }

        public void BuildBasicLaptop()
        {
            _builder.SetProductName("Basic Laptop");
            _builder.SetPrice(799.99M);
            _builder.SetCategory("Electronics");
            _builder.SetDescription("A basic laptop for everyday use.");
            _builder.SetSKU("LAPTOP-BASIC-123");
            _builder.SetStock(50);
        }
    }
```

In this code, we define a private field of type `IProductBuilder`. 

Next we have a method `BuildBasicLaptop`. Here, as the Director class is responsable for some default products, we set to `BasicLaptop` some default values. In main `Program`, the usage of `Director` class is shown below.

**Usage Example:**

```csharp
ProductDirector director = new ProductDirector(builder);
director.BuildGamingLaptop();
Product gamingLaptop = ((ProductBuilder)builder).Build();
```

In this code, first we create an instance of `ProductDirector` class.

Second we build a Basic Laptop using the `Director` class. 

In next line, we create a field of type `Product` and assign to it the value of the builded product, using `ProductBuilder` class, specifically method `Build`.

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
}
```

First, we define an interface `IShoppingCart`. It has 2 abstract methods: 

`AddProduct` - adding a product to the shopping cart

`GetProducts` - getting all products from the cart as a list 

Next, it is defined a class `ShoppingCart` which implments the above interface. It has 2 private fields: 

`_instance` - `ShoppingCart` instance which will be used to return just one instance of this class

`_products` - list of products 

Next, we define an `Instance` property. In the get accessor of `Instance`, it checks if `_instance` is null. If it is, it creates a new `ShoppingCart` instance; otherwise, it returns the already-created instance.

The constructor is private (`private ShoppingCart()`), meaning other classes cannot instantiate ShoppingCart directly.

**Usage Example:**

```csharp
IShoppingCart cart = ShoppingCart.Instance;
cart.AddProduct(new Product("Laptop", 1000));
List<IProduct> products = cart.GetProducts();
```
First line retrieves the singleton instance of `ShoppingCart` through its `Instance` property and assigns it to the `cart` variable.

Next to the `cart` is added a new product. After this, the products from cart are extractd into `products`, a list of all products.


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

First, we define an interface `IPayment`, which has an abstract method of `ProcessPayment`.

Next, we define an abstract class `Payment`, having also an abstract method `ProcessPayment`.

After this, we define a class `CreditCardPayment` which implements the astract class `Payment`. It has a method `ProcessPayment` which ovrrides the abstract method. This method just prints the payment method used.

Similar to `CreditCardPayment`, in this work is defined `PayPalPayment`, with the same implementation.

Next, we have the class `PaymentFactory`. It has a method `CreatePayment`, which returns either `CreditCardPayment` or `PayPalPayment`. This method takes as argument the `type` of payment. Inside the method we have a `switch case`, which compares the argument with existing payment method and returns a required instance.

**Usage Example:**

```csharp
IPayment payment = PaymentFactory.CreatePayment("PayPal");
payment.ProcessPayment();
```

In this case, `payment` is an object of type `IPayment`. To it is assigned an instance of `PayPalPayment` by using `CreatePayment` method of the `PaymentFactory` class.

In next line, we use `ProcessPayment` method to display "Processing PayPal payment..." (in our case, this being the implementation of `ProcessPayment` method in `PayPalPayment` class).

### **Conclusion**

In this project, I successfully implemented several **Creational Design Patterns** in an eCommerce domain, focusing on efficient and flexible object creation. The **Builder Pattern** allowed us to create complex product objects step by step, while the **Singleton Pattern** ensured the proper management of shared instances like the shopping cart. Additionally, the **Factory Method Pattern** provided a modular approach for creating different payment methods. These patterns not only improved the flexibility and scalability of the system but also adhered to SOLID principles, making the codebase easier to maintain and extend in the future. 

