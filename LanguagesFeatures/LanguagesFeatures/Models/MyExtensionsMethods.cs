namespace LanguagesFeatures.Models
{
    public static class MyExtensionsMethods
    {
        public static decimal TotalPrice(this ShopingCart cartParam)
        {
            decimal totalPrice = 0;
            foreach (var product in cartParam.Products)
            {
                totalPrice += product?.Price ?? 0;
            }

            return totalPrice;
        }
    }
}
