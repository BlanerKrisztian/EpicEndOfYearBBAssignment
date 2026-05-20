namespace ShoppingCartApp
{
    public class Discount
    {
        // percent: 0–100 között, különben ArgumentException
        // Példa: ApplyPercentage(200, 10) -> 180
        public double ApplyPercentage(double total, double percent)
        {
            if (percent < 0 || percent > 100)
            {
                throw new ArgumentException("Invalid Percent range");
            }
            double newPrice = total - total * (percent / 100);
            return newPrice;
        }

        // Az eredmény soha nem lehet negatív — ha a kedvezmény nagyobb, 0-t ad vissza
        // Példa: ApplyFixed(100, 50) -> 50
        public double ApplyFixed(double total, double discountAmount)
        {
            if (discountAmount < 0)
            {
                throw new ArgumentException("Discount cannot be negative", "discountAmount");
            }
            double fixedValue = total - discountAmount;
            if (fixedValue < 0)
            {
                fixedValue = 0;
            }
            return fixedValue;
        }

        // true ha discountValue > 0
        public bool IsValid(double discountValue)
        {
            if (discountValue <= 0)
            {
                return false;
            }
            return true;
        }
    }
}
