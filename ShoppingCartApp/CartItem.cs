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
            if (name.Trim() == "" || name == "" || name is null || unitPrice <= 0 || quantity < 1)
            {
                throw new ArgumentException("Invalid argument");
            }
            Name = name.Trim();
            UnitPrice = unitPrice;
            Quantity = quantity;
        }

        // UnitPrice * Quantity
        public double GetLineTotal()
        {
            double linetotal = UnitPrice * Quantity;
            return linetotal;
        }

        // quantity >= 1, különben ArgumentException
        public void UpdateQuantity(int quantity)
        {
            if (quantity < 1)
            {
                throw new ArgumentException("Quantity cannot be less than one.", "quantity");
            }
            Quantity = quantity;
        }
    }
}
    