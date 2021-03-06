using System.Collections.Generic;

namespace Given_A_PotterCalculator
{
    public class PotterCalculator
    {
        public decimal Calculate(List<BookTitle> books)
        {
            var bookCounter = new BookCounter(books);
            var numberOfUniqueBooks = bookCounter.GetNumberOfUniqueBooks();
            var numberOfDuplicateBooks = bookCounter.GetNumberOfDuplicateBooks();

            var priceCounter = new PriceCalculator();
            var priceOfUniqueBooks = priceCounter.GetPriceOfUniqueBooks(numberOfUniqueBooks);
            var priceOfDuplicateBooks = priceCounter.GetPriceOfDuplicateBooks(numberOfDuplicateBooks);
            var totalPrice = priceOfDuplicateBooks + priceOfUniqueBooks;

            return totalPrice;
        }
    }
}