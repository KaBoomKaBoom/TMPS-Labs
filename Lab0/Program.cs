Product product1 = new Product("Laptop", 1000m);
Product product2 = new Product("Mouse", 50m);

// Apply 10% discount using OCP.
IDiscountStrategy discountStrategy = new PercentageDiscountStrategy(10m);

ShoppingCart cart = new ShoppingCart(discountStrategy);
cart.AddProduct(product1);
cart.AddProduct(product2);

Console.WriteLine($"Total price with discount: {cart.GetTotal()}");
