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
            if (name.ToLower() == "" || name is null)
            {
                throw new ArgumentException("Name Cannot be empty","name");
            }
            else if(unitPrice <= 0)
            {
                throw new ArgumentException("Price cannot be negative", "unitPrice");
            }
            else if (quantity < 0)
            {
                throw new ArgumentException("Quantity cannot be negative");
            }
            _items.Add(new CartItem(name.ToLower(), unitPrice, quantity));
            
        }

        // true ha megtalálta és törölte, false ha nem szerepelt
        public bool RemoveItem(string name)
        {
            foreach (CartItem item in _items)
            {
                int founditems = 0;
                if (item.Name.ToLower() == name.ToLower())
                {
                    _items.Remove(item);
                    founditems++;
                }
                if (founditems > 0)
                {
                    return true;
                }
                
            }
            return false;
        }

        public int GetItemCount()
        {
            int itemCount = _items.Sum(i => i.Quantity);
            return itemCount;
        }

        // Összeg = minden item (UnitPrice * Quantity) összege
        public decimal GetTotal()
        {
            decimal total = Convert.ToDecimal(_items.Sum(i => i.UnitPrice * i.Quantity));
            return total;
        }

        public IReadOnlyList<CartItem> GetItems()
        {
            List<CartItem> items = _items;
            return items;
        }

        public void Clear()
        {
            _items.Clear();
        }
    }
}
