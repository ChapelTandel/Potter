namespace Given_A_PotterCalculator
{
    public class PriceCalculator
    {
        public decimal GetPriceOfUniqueBooks(int numberOfUniqueBooks)
        {
            var discountCalculator = new DiscountCalculator();
            switch (numberOfUniqueBooks)
            {
                case (1):
                    return discountCalculator.GetDiscount(0);
                case (3):
                    return discountCalculator.GetDiscount(10);
                case (4):
                    return discountCalculator.GetDiscount(20);
                case (5):
                    return discountCalculator.GetDiscount(25);
                default:
                    return discountCalculator.GetDiscount(5);
            }
        }

        public decimal GetPriceOfDuplicateBooks(int numberOfDuplicateBooks)
        {
            return numberOfDuplicateBooks*8M;
        }
    }
}