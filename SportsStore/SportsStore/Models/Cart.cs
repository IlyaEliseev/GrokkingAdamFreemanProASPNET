namespace SportsStore.Models
{
    public class Cart
    {
        private List<CartLine> _lineCollection = new List<CartLine>();

        public virtual void AddItem(Product product, int quantity)
        {
            var cartLine = _lineCollection
                .Where(x =>x.Product.ProductId == product.ProductId)
                .FirstOrDefault();

            if (cartLine == null)
            {
                _lineCollection.Add(new CartLine
                {
                    Product = product,
                    Quantity = quantity
                });
            }
            else
            {
                cartLine.Quantity += quantity;
            }
        }

        public virtual void RemoveLine(Product product)
        {
            _lineCollection.RemoveAll(x => x.Product.ProductId == product.ProductId);
        }

        public virtual decimal ComputeTotalValue() => _lineCollection.Sum(x => x.Product.Price * x.Quantity);

        public virtual void Clear() => _lineCollection.Clear();

        public virtual IEnumerable<CartLine> Lines => _lineCollection;
    }
}
