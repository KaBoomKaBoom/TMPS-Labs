namespace Lab3.Product
{
    public class ProductBuilder : IProductBuilder
    {
        private string? _name;
        private decimal _price;
        private string? _category;
        private string? _description;
        private string? _sku;
        private int _stock;

        public void SetProductName(string name)
        {
            if (name == "")
            {
                _name = "";
            }
            else
            {
                _name = name;
            }
        }

        public void SetPrice(decimal price)
        {
            if (price < 0)
            {
                throw new ArgumentException("Price cannot be negative");
            }
            else
            {
                _price = price;
            }
        }

        public void SetCategory(string category)
        {
            if (category == "")
            {
                _category = "";
            }
            else
            {
                _category = category;
            }
        }

        public void SetDescription(string description)
        {
            if (description == "")
            {
                _description = "";
            }
            else
            {
                _description = description;
            }
        }

        public void SetSKU(string sku)
        {
            if (sku == "")
            {
                _sku = "";
            }
            else
            {
                _sku = sku;
            }
        }

        public void SetStock(int stock)
        {
            if (stock < 0)
            {
                throw new ArgumentException("Stock cannot be negative");
            }
            else
            {
                _stock = stock;
            }

        }

        // Return the fully built Product object
        public Product Build()
        {
            return new Product(_name, _price, _category, _description, _sku, _stock);
        }
    }
}