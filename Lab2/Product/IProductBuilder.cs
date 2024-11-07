namespace Lab2.Product
{
    public interface IProductBuilder
    {
        void SetProductName(string name);
        void SetPrice(decimal price);
        void SetCategory(string category);
        void SetDescription(string description);
        void SetSKU(string sku);
        void SetStock(int stock);
    }
}