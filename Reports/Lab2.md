### Structural Design Patterns  
**Author:** Berco Andrei, FAF - 221  

---

### **Objectives:**

- Study and understand the Structural Design Patterns.
- As a continuation of the previous laboratory work, think about the functionalities that your system will need to provide to the user.
- Implement some additional functionalities using structural design patterns.

---

### **Domain: eCommerce System**

The domain selected for this report is an **eCommerce System**. The system handles product management, order creation, and payment processing, allowing customers to browse products, add them to a cart, and complete purchases. The implementation leverages creational design patterns to ensure flexibility, scalability, and ease of future enhancements.

--- 

### **Used Patterns**

In this project, I implemented several **Structural Design Patterns** to help to perform the tasks involved in the system:

1. **Facade Pattern**  
    A facade is a class that provides a simple interface to a complex subsystem which contains lots of moving parts. A facade might provide limited functionality in comparison to working with the subsystem directly. However, it includes only those features that clients really care about.

    ![Alt text](/Images/FacadePattern.png)


2. **Decorator Pattern**  
    Decorator is a structural design pattern that lets you attach new behaviors to objects by placing these
    objects inside special wrapper objects that contain the behaviors.

    ![Alt text](/Images/DecoratorPattern.png)


3. **Composite Pattern**  
    Composite is a structural design pattern that lets you compose objects into tree structures and then work
    with these structures as if they were individual objects.

    ![Alt text](/Images/CompositePattern.png)

---

### **Implementation of Creational Design Patterns**

In this project, I implemented the **Facade**, **Decorator**, and **Composite** patterns to handle various aspects of the eCommerce system. Below are the implementation details with code snippets:

---

#### **1. Facade Pattern**

The **Facade Pattern** was used here to simplify and centralize the process of creating and using payment methods. I defined a `PaymentFacade` class that uses the factory to create the payment method and process the payment.

**Code Snippet:**

Lab2/Payement/PaymentFacade.cs
```csharp
    public class PaymentFacade
    {
        public void ProcessPayment(string paymentType, decimal amount)
        {
            IPayment paymentMethod = PaymentFactory.CreatePayment(paymentType);
            paymentMethod.ProcessPayment();
            Console.WriteLine($"Payment of {amount:C} processed successfully using {paymentType}.");
        }
    }
```

In the class `PayementFacade` is defined a method `ProcessPayement`. It takes as argumnts the payement type provided by client and the amount of payements.

Next, it is created a `payemetMethod` using the `CreatePayment` function from the `PaymentFactory` class based on the type of payement. After this, the payement is processed using `ProcessPayment` function.

After execution of the above function, to console is printed that the payement was processed succesfully.

**Usage Example:**

Lab2/Program.cs
```csharp
PaymentFacade paymentFacade = new PaymentFacade();
paymentFacade.ProcessPayment("CreditCard", 1000.00M);
```
In this usage example, first we create an instance of `PaymentFacade`. After that, we use `ProcessPayment` function from `PaymentFacade` class, giving it just the payement type and amount as arguments.

#### **2. Decorator Pattern**

The **Decorator Pattern** was used to add new functionality to existing objects (product) dynamically without altering their structure or core functionality..

**Code Snippet:**

Lab2/Product/DiscountDecorator.cs
```csharp 
    public class DiscountDecorator : IProduct
    {
        private readonly IProduct _product;
        private readonly decimal _discountPercentage;

        public DiscountDecorator(IProduct product, decimal discountPercentage)
        {
            _product = product;
            _discountPercentage = discountPercentage;
        }

        public string Name => _product.Name;
        public decimal Price => _product.Price * (1 - _discountPercentage);
        public string Category => _product.Category;
        public string Description => _product.Description;
        public string SKU => _product.SKU;
        public int Stock => _product.Stock;

        public void DisplayProductInfo()
        {
            Console.WriteLine($"Product: {Name}, Price: {Price:C}, Category: {Category}, Description: {Description}, SKU: {SKU}, Stock: {Stock}");
        }
    }
```

In the above code, first is declared the class `DiscountDecorator`. In it are declared 2 private fields : `_product` and `_discountPercentage`.

Next, we use a constructor to take a product and a discountPercentage as parameters of object creation.

Next, the propreties are passed through to the underlying `_product` instance without modifications except the `Price`.

`Price` proprety is overrided, applying a discount by calculating Price * (1 - _discountPercentage).

Finally, the `DisplayProductInfo` method showcases the modified price while retaining other product details

Simillary, there is one more decorator, `TaxDecorator`. It has the same logic as `DiscountDecorator`, just the `Price` proprety is modified in another way.

**Usage Example:**

Lab2/Program.cs
```csharp
IProduct discountedProduct = new DiscountDecorator(product, 0.10M);
Console.WriteLine("Product Info After 10% Discount:");
discountedProduct.DisplayProductInfo();
```

First, we suppose we have already created a `product`.

Next, we create another product using the `DiscountDecorator`, by passing as arguments the `product` itself and the dicount value.

Next, we use the `DisplayProductInfo` function to display the information about the product.

#### **3. Composite Pattern**

The **Composite Pattern** allows us to treat individual objects and groups of objects (composites) uniformly.  In the code below, `ProductCategory` acts as a composite structure that can hold both single products and other product categories, enabling hierarchical composition and operations on these structures.

**Code Snippet:**

Lab2/Product/ProductCategory.cs
```csharp
public class ProductCategory : IProduct
{
    private readonly List<IProduct> _components = new List<IProduct>();
    public string Name { get; }
}

```
`ProductCategory`  implements the `IProduct` interface, which allows it to be treated as an individual product or a group of products. 

`_components` is a list that holds `IProduct` instances

```csharp
public ProductCategory(string name)
{
    Name = name;
}
```
`ProductCategory` is a constructor which initializes with a given name.

```csharp
public void AddComponent(IProduct component)
{
    _components.Add(component);
}

public void RemoveComponent(IProduct component)
{
    _components.Remove(component);
}
```

`AddComponent` method adds an `IProduct component` to the `_components`.

`RemoveComponent` method removes an `IProduct component` from the `_components`.

```csharp
public decimal Price => _components.Sum(c => c.Price);
public string Category => Name;
public string Description => $"Product Category: {Name}";
public string SKU => $"CAT-{Name.ToUpper().Replace(" ", "-")}";
public int Stock => _components.Sum(c => c.Stock);
```

`Price` property calculates the total price of all components within the category.

`Category` property returns the name of the category.

`Stock` property computes the total stock.


**Usage Example:**

```csharp
ProductCategory clothingCategory = new ProductCategory("Clothing");
clothingCategory.AddComponent(shirt);
clothingCategory.AddComponent(pants);
```
First, we suppose we have already created the products `shirt` and `pants`.

Next, we create a `clothingCategory` by using `ProductCategory` with the argument of category name.

After this, we add our products intot the category, by using `AddComponent` function.

Finally, we can display all products from this category.
 
### **Conclusion**

In this project, I successfully implemented several **Structural Design Patterns** in an eCommerce domain. The **Facade  Pattern** allowed us to enhance interaction with the payement system, making client interaction with the code easier by wraping payemennt logic inside the facade class. The **Decorator Pattern** enabled adding different features, like taxes or discounts to product, without modifying the core functionality of product itself. The last pattern used was **Composite**, which allowed us to develop a hierarchy of products, making easier the management of complex strucutres.

