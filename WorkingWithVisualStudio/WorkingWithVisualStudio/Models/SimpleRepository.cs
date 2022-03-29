namespace WorkingWithVisualStudio.Models
{
    public class SimpleRepository
    {
        private static SimpleRepository simpleRepository 
            = new SimpleRepository();

        private Dictionary<string, Product> _products 
            = new Dictionary<string, Product>();

        public static SimpleRepository ShareRepository => simpleRepository;

        public SimpleRepository()
        {
            var products = new[] {
                new Product {Name = "Kayak", Price = 275M },
                new Product {Name = "LifeJacket", Price = 48.95M },
                new Product {Name = "SoccerBall", Price = 19.50M },
                new Product {Name = "CornerFlag", Price = 34.95M },
            };

            foreach (var product in products)
            {
                AddProduct(product);
            }
        }

        public IEnumerable<Product> Products => _products.Values;

        public void AddProduct(Product product) => _products.Add(product.Name, product);
    }
}
