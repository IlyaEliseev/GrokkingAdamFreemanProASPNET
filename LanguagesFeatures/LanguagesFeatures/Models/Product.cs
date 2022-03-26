namespace LanguagesFeatures.Models
{
    public class Product
    {
        public string Name { get; set; }

        public decimal? Price { get; set; }

        public Product Related { get; set; }

        public string Category { get; set; } = "WaterSports";
        public static Product[] GetProducts()
        {
            Product kayak = new Product
            {
                Name = "Kayak",
                Price = 275M,
                Category = "Water Craft"
            };
            Product lifeJacket = new Product { Name = "LifeJacket", Price = 48.95M };
            kayak.Related = lifeJacket;
            return new Product[] { kayak, lifeJacket, null };
        }
    }
}
