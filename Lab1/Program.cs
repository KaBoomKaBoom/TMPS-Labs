using Lab1.Payment;
using Lab1.Product;
using Lab1.ShoppingCart;

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
List<Product> products = cart.GetProducts();

// Display products in the shopping cart
foreach (Product product in products)
{
    product.DisplayProductInfo();
}
Console.WriteLine();

// Factory Method: Creating a payment method
IPayment payment = PaymentFactory.CreatePayment("PayPal");
payment.ProcessPayment();