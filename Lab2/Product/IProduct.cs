namespace Lab2.Product
{
    public interface IProduct
    {
        string Name { get; }
        decimal Price { get; }
        string Category { get; }
        string Description { get; }
        string SKU { get; }
        int Stock { get; }

        void DisplayProductInfo();
    }
}