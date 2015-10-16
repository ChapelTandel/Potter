using System;
using System.Collections.Generic;

namespace Given_A_PotterCalculator
{
    internal class BookCounter
    {
        public BookCounter(IEnumerable<BookTitle> books)
        {
            foreach (var book in books)
            {
                AddCount(book);
            }
        }

        public int FirstBookCount { get; set; }
        public int SecondBookCount { get; set; }
        public int ThirdBookCount { get; set; }
        public int FifthBookCount { get; set; }
        public int FourthBookCount { get; set; }

        private void AddCount(BookTitle title)
        {
            switch (title)
            {
                case (BookTitle.TitleOne):
                    FirstBookCount++;
                    break;
                case (BookTitle.TitleTwo):
                    SecondBookCount++;
                    break;
                case (BookTitle.TitleThree):
                    ThirdBookCount++;
                    break;
                case (BookTitle.TitleFour):
                    FourthBookCount++;
                    break;
                case (BookTitle.TitleFive):
                    FifthBookCount++;
                    break;
                default:
                    throw new Exception("Incorrect book title");
            }
        }


        public int GetCountOfTotalBooks(BookCounter bookCounter)
        {
            return bookCounter.FirstBookCount + bookCounter.SecondBookCount + bookCounter.ThirdBookCount +
                   bookCounter.FourthBookCount + bookCounter.FifthBookCount;
        }

        public int GetNumberOfUniqueBooks(BookCounter bookCounter)
        {
            var count = 0;

            if (bookCounter.FirstBookCount > 0) count++;
            if (bookCounter.SecondBookCount > 0) count++;
            if (bookCounter.ThirdBookCount > 0) count++;
            if (bookCounter.FourthBookCount > 0) count++;
            if (bookCounter.FifthBookCount > 0) count++;

            return count;
        }

        public int GetNumberOfDuplicateBooks(BookCounter bookCounter)
        {
            return GetCountOfTotalBooks(bookCounter) - GetNumberOfUniqueBooks(bookCounter);
        }
    }
}