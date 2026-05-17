namespace ShoppingCartApp
{
    public class Discount
    {
        // percent: 0–100 között, különben ArgumentException
        // Példa: ApplyPercentage(200, 10) -> 180
        public double ApplyPercentage(double total, double percent)
        {
            throw new NotImplementedException();
        }

        // Az eredmény soha nem lehet negatív — ha a kedvezmény nagyobb, 0-t ad vissza
        // Példa: ApplyFixed(100, 50) -> 50
        public double ApplyFixed(double total, double discountAmount)
        {
            throw new NotImplementedException();
        }

        // true ha discountValue > 0
        public bool IsValid(double discountValue)
        {
            throw new NotImplementedException();
        }
    }
}
