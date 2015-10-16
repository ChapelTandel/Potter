using System;
using System.Collections.Generic;

namespace Given_A_PotterCalculator
{
    internal class BookCounter
    {
        public BookCounter(IEnumerable<BookTitle> books)
        {
            var bookCahceLsit = new List<BookCache>();

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


        public int GetCountOfTotalBooks()
        {
            return FirstBookCount
                   + SecondBookCount
                   + ThirdBookCount
                   + FourthBookCount
                   + FifthBookCount;
        }

        public int GetNumberOfUniqueBooks()
        {
            var count = 0;

            if (FirstBookCount > 0) count++;
            if (SecondBookCount > 0) count++;
            if (ThirdBookCount > 0) count++;
            if (FourthBookCount > 0) count++;
            if (FifthBookCount > 0) count++;

            return count;
        }

        public int GetNumberOfDuplicateBooks()
        {
            return GetCountOfTotalBooks() - GetNumberOfUniqueBooks();
        }
    }

    internal class BookCache
    {
        public BookTitle Title { get; set; }
        public int Quantity { get; set; }
    }
}