//Comosite Pattern reat individual products and product categories uniformly

namespace Lab3.Product
{
    public class ProductCategory : IProduct
    {
        private readonly List<IProduct> _components = new List<IProduct>();
        public string Name { get; }

        public ProductCategory(string name)
        {
            Name = name;
        }

        public void AddComponent(IProduct component)
        {
            _components.Add(component);
        }

        public void RemoveComponent(IProduct component)
        {
            _components.Remove(component);
        }

        public decimal Price => _components.Sum(c => c.Price);
        public string Category => Name;
        public string Description => $"Product Category: {Name}";
        public string SKU => $"CAT-{Name.ToUpper().Replace(" ", "-")}";
        public int Stock => _components.Sum(c => c.Stock);

        public void DisplayProductInfo()
        {
            Console.WriteLine($"Product Category: {Name}, Total Price: {Price:C}, Total Stock: {Stock}");
            foreach (var component in _components)
            {
                component.DisplayProductInfo();
            }
        }
    }
}