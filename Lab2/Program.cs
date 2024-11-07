using Lab2.Payment;
using Lab2.Product;
using Lab2.ShoppingCart;

//BUILDING PRODUCTS USING THE BUILDER PATTERN
// Create the builder
IProductBuilder builder = new ProductBuilder();

// Use the director to create predefined products
ProductDirector director = new ProductDirector(builder);

// Build a basic laptop
director.BuildBasicLaptop();
Product basicLaptop = ((ProductBuilder)builder).Build();

// Build a gaming laptop
director.BuildGamingLaptop();
Product gamingLaptop = ((ProductBuilder)builder).Build();

// Alternatively, use the builder directly for a custom product
builder.SetProductName("Custom PC");
builder.SetPrice(1500.00M);
builder.SetCategory("Electronics");
builder.SetDescription("A custom-built gaming PC.");
builder.SetSKU("PC-CUSTOM-001");
builder.SetStock(10);
Product customPC = ((ProductBuilder)builder).Build();

//Display product info using product class method
basicLaptop.DisplayProductInfo();
gamingLaptop.DisplayProductInfo();
customPC.DisplayProductInfo();
Console.WriteLine();

// Singleton: Accessing the single shopping cart instance
ShoppingCart cart = ShoppingCart.Instance;
cart.Products.Add(basicLaptop);
cart.Products.Add(gamingLaptop);
cart.Products.Add(customPC);

// Display products in the shopping cart
Console.WriteLine("Shopping Cart:");
foreach (Product product in cart.Products)
{
    product.DisplayProductInfo();
}
Console.WriteLine();

// Facade: Process payments using different payment methods
PaymentFacade paymentFacade = new PaymentFacade();
paymentFacade.ProcessPayment("CreditCard", 1000.00M);
paymentFacade.ProcessPayment("ApplePay", 1500.00M);
paymentFacade.ProcessPayment("GooglePay", 2000.00M);
paymentFacade.ProcessPayment("PayPal", 2500.00M);


// Factory Method: Creating a payment method
// IPayment payment = PaymentFactory.CreatePayment("PayPal");
// payment.ProcessPayment();