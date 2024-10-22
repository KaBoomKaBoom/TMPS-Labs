namespace Lab1.Product
{
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

        public void BuildGamingLaptop()
        {
            _builder.SetProductName("Gaming Laptop");
            _builder.SetPrice(1999.99M);
            _builder.SetCategory("Electronics");
            _builder.SetDescription("A high-end gaming laptop.");
            _builder.SetSKU("LAPTOP-GAMING-999");
            _builder.SetStock(20);
        }
    }
}