﻿using Lab2.Payment;
using Lab2.Product;
using Lab2.ShoppingCart;

// Facade: Process payments using different payment methods
PaymentFacade paymentFacade = new PaymentFacade();
paymentFacade.ProcessPayment("CreditCard", 1000.00M);
paymentFacade.ProcessPayment("ApplePay", 1500.00M);
paymentFacade.ProcessPayment("GooglePay", 2000.00M);
paymentFacade.ProcessPayment("PayPal", 2500.00M);
Console.WriteLine();

//Decorator Pattern 
IProductBuilder builder = new ProductBuilder();

// Create a base product
builder.SetProductName("T-Shirt");
builder.SetPrice(190.99m);
builder.SetCategory("Clothing");
builder.SetDescription("100% cotton t-shirt");
builder.SetSKU("TS-001");
builder.SetStock(50);
Product product = ((ProductBuilder)builder).Build();

Console.WriteLine("Initial Product Info:");
product.DisplayProductInfo();
Console.WriteLine();

// Decorator: Apply a 10% discount to the product
IProduct discountedProduct = new DiscountDecorator(product, 0.10M);
Console.WriteLine("Product Info After 10% Discount:");
discountedProduct.DisplayProductInfo();
Console.WriteLine();

// Decorator: Apply a 5% tax to the product
IProduct taxedProduct = new TaxDecorator(product, 0.05M);
Console.WriteLine("Product Info After 5% Tax:");
taxedProduct.DisplayProductInfo();
Console.WriteLine();

//Composite Pattern
// Create some products
builder.SetProductName("T-Shirt");
builder.SetPrice(190.99m);
builder.SetCategory("Clothing");
builder.SetDescription("100% cotton t-shirt");
builder.SetSKU("TS-001");
builder.SetStock(50);
Product shirt = ((ProductBuilder)builder).Build();

builder.SetProductName("Pants");
builder.SetPrice(44.99m);
builder.SetCategory("Clothing");
builder.SetDescription("100% cotton t-shirt");
builder.SetSKU("P-001");
builder.SetStock(23);
Product pants = ((ProductBuilder)builder).Build();

// Create a product category
ProductCategory clothingCategory = new ProductCategory("Clothing");
clothingCategory.AddComponent(shirt);
clothingCategory.AddComponent(pants);

// Display the product category information
Console.WriteLine("Category using composite pattern:");
clothingCategory.DisplayProductInfo();




//BUILDING PRODUCTS USING THE BUILDER PATTERN
// Create the builder
// IProductBuilder builder = new ProductBuilder();

// // Use the director to create predefined products
// ProductDirector director = new ProductDirector(builder);

// // Build a basic laptop
// director.BuildBasicLaptop();
// Product basicLaptop = ((ProductBuilder)builder).Build();

// // Build a gaming laptop
// director.BuildGamingLaptop();
// Product gamingLaptop = ((ProductBuilder)builder).Build();

// Alternatively, use the builder directly for a custom product
// builder.SetProductName("Custom PC");
// builder.SetPrice(1500.00M);
// builder.SetCategory("Electronics");
// builder.SetDescription("A custom-built gaming PC.");
// builder.SetSKU("PC-CUSTOM-001");
// builder.SetStock(10);
// Product customPC = ((ProductBuilder)builder).Build();

// //Display product info using product class method
// basicLaptop.DisplayProductInfo();
// gamingLaptop.DisplayProductInfo();
// customPC.DisplayProductInfo();
// Console.WriteLine();

// // Singleton: Accessing the single shopping cart instance
// ShoppingCart cart = ShoppingCart.Instance;
// cart.Products.Add(basicLaptop);
// cart.Products.Add(gamingLaptop);
// cart.Products.Add(customPC);

// // Display products in the shopping cart
// Console.WriteLine("Shopping Cart:");
// foreach (Product product in cart.Products)
// {
//     product.DisplayProductInfo();
// }
// Console.WriteLine();



// Factory Method: Creating a payment method
// IPayment payment = PaymentFactory.CreatePayment("PayPal");
// payment.ProcessPayment();