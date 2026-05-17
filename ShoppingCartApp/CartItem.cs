namespace ShoppingCartApp
{
    public class CartItem
    {
        public string Name { get; }
        public double UnitPrice { get; }
        public int Quantity { get; private set; }

        // name nem lehet null/üres, unitPrice > 0, quantity >= 1
        public CartItem(string name, double unitPrice, int quantity)
        {
            throw new NotImplementedException();
        }

        // UnitPrice * Quantity
        public double GetLineTotal()
        {
            throw new NotImplementedException();
        }

        // quantity >= 1, különben ArgumentException
        public void UpdateQuantity(int quantity)
        {
            throw new NotImplementedException();
        }
    }
}
