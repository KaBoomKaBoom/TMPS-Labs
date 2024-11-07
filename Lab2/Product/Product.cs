namespace Lab2.Product
{
    public class Product : IProduct
    {
        public string Name { get; private set; }
        public decimal Price { get; private set; }
        public string Category { get; private set; }
        public string Description { get; private set; }
        public string SKU { get; private set; }
        public int Stock { get; private set; }

        public Product(string name, decimal price, string category, string description, string sku, int stock)
        {
            Name = name;
            Price = price;
            Category = category;
            Description = description;
            SKU = sku;
            Stock = stock;
        }

        public void DisplayProductInfo()
        {
            Console.WriteLine($"Product: {Name}, Price: {Price}, Category: {Category}, Description: {Description}, SKU: {SKU}, Stock: {Stock}");
        }
    }
}