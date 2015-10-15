using System.Collections.Generic;

namespace Given_A_PotterCalculator
{
    public class PotterCalculator
    {
        public decimal Calculate(List<BookTitle> books)
        {
            var bookCounter = new BookCounter();

            bookCounter.CountIndividualBooks(books);

            var totalBooks = bookCounter.GetCountOfTotalBooks(bookCounter);

            var numberOfUniqueBooks = bookCounter.GetNumberOfUniqueBooks(bookCounter);

            var numberOfDuplicateBooks = totalBooks - numberOfUniqueBooks;

            var priceOfUniqueBooks = GetDiscountedPriceOfUniqueBooks(numberOfUniqueBooks);

            var priceOfDuplicateBooks = GetPriceOfDuplicateBooks(numberOfDuplicateBooks);

            var totalPrice = priceOfDuplicateBooks + priceOfUniqueBooks;

            return totalPrice;
        }

        private static decimal GetPriceOfDuplicateBooks(int numberOfDuplicateBooks)
        {
            return numberOfDuplicateBooks*8M;
        }

        private static decimal GetDiscountedPriceOfUniqueBooks(int numberOfUniqueBooks)
        {
            switch (numberOfUniqueBooks)
            {
                case (1):
                    return GetDiscount(0);
                case (3):
                    return GetDiscount(10);
                case (4):
                    return GetDiscount(20);
                case (5):
                    return GetDiscount(25);
                default:
                    return GetDiscount(5);
            }
        }

        public static decimal GetDiscount(int discountPercent)
        {
            switch (discountPercent)
            {
                case (5):
                    return 0.95M*8*2;
                case (10):
                    return .90M*8*3;
                case (20):
                    return 0.80M*8*4;
                case (25):
                    return 0.75M*8*5;
                default:
                    return 8m;
            }
        }
    }
}