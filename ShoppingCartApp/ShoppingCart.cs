namespace ShoppingCartApp
{
    public class ShoppingCart
    {
        private readonly List<CartItem> _items;

        public ShoppingCart()
        {
            _items = new List<CartItem>();
        }

        // Ha az item neve már szerepel (kis-nagybetű független), növeli a mennyiségét
        public void AddItem(string name, double unitPrice, int quantity)
        {
            throw new NotImplementedException();
        }

        // true ha megtalálta és törölte, false ha nem szerepelt
        public bool RemoveItem(string name)
        {
            throw new NotImplementedException();
        }

        public int GetItemCount()
        {
            throw new NotImplementedException();
        }

        // Összeg = minden item (UnitPrice * Quantity) összege
        public decimal GetTotal()
        {
            throw new NotImplementedException();
        }

        public IReadOnlyList<CartItem> GetItems()
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }
    }
}
