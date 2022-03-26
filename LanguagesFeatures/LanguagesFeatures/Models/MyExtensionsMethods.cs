namespace LanguagesFeatures.Models
{
    public static class MyExtensionsMethods
    {
        public static decimal TotalPrice(this IEnumerable<Product> products)
        {
            decimal totalPrice = 0;
            foreach (var product in products)
            {
                totalPrice += product?.Price ?? 0;
            }

            return totalPrice;
        }

        public static IEnumerable<Product> FilterByPrice(this IEnumerable<Product> productEnum, decimal minimalPrice)
        {
            foreach (var product in productEnum)
            {
                if ((product?.Price ?? 0) > minimalPrice)
                {
                    yield return product;
                }
            }
        }

        public static IEnumerable<Product> Filter(this IEnumerable<Product> productEnum, Func<Product, bool> selector)
        {
            foreach(var product in productEnum)
            {
                if (selector(product))
                {
                    yield return product;
                }
            }
        }
    }
}
