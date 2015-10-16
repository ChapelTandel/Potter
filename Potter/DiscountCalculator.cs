namespace Given_A_PotterCalculator
{
    public class DiscountCalculator
    {
        public decimal GetDiscount(int discountPercent)
        {
            switch (discountPercent)
            {
                case (5):
                    return 0.95M * 8 * 2;
                case (10):
                    return .90M * 8 * 3;
                case (20):
                    return 0.80M * 8 * 4;
                case (25):
                    return 0.75M * 8 * 5;
                default:
                    return 8m;
            }
        }
    }
}