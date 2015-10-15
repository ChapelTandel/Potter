using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;

namespace Given_A_PotterCalculator
{
    [TestFixture]
    public class When_I_Checkout_With_Any_One_Book
    {
        [TestCase(BookTitle.TitleOne, 8.00)]
        [TestCase(BookTitle.TitleTwo, 8.00)]
        public void Then_The_Basket_Total_Is_Eight(BookTitle title, double expected)
        {
            var potterCalculator = new PotterCalculator();

            var actual = potterCalculator.Calculate(new List<BookTitle> {title});

            Assert.That(actual, Is.EqualTo(expected));
        }
    }

    [TestFixture]
    public class When_I_Checkout_With_Two_Different_Books
    {
        [TestCase(BookTitle.TitleOne, BookTitle.TitleTwo)]
        [TestCase(BookTitle.TitleOne, BookTitle.TitleThree)]
        [TestCase(BookTitle.TitleTwo, BookTitle.TitleThree)]
        public void Then_I_Get_5_Percent_Discount(BookTitle firstBookTitle, BookTitle secondBookTitle)
        {
            var potterCalculator = new PotterCalculator();
            var bookList = new List<BookTitle> {firstBookTitle, secondBookTitle};

            Assert.That(potterCalculator.Calculate(bookList), Is.EqualTo(15.20M));

            potterCalculator.Calculate(bookList)
                .Should()
                .Be(15.2M, "When you have two different books in you basket, you get 5% discount");
        }
    }

    [TestFixture]
    public class When_I_Checkout_With_Three_Different_Books
    {
        [TestCase(BookTitle.TitleOne, BookTitle.TitleTwo, BookTitle.TitleThree)]
        [TestCase(BookTitle.TitleOne, BookTitle.TitleThree, BookTitle.TitleFour)]
        [TestCase(BookTitle.TitleTwo, BookTitle.TitleThree, BookTitle.TitleFive)]
        public void Then_I_Get_5_Percent_Discount(BookTitle firstBookTitle, BookTitle secondBookTitle,
            BookTitle thirdBookTitle)
        {
            var potterCalculator = new PotterCalculator();
            var bookList = new List<BookTitle> {firstBookTitle, secondBookTitle, thirdBookTitle};

            Assert.That(potterCalculator.Calculate(bookList), Is.EqualTo(21.6M));

            potterCalculator.Calculate(bookList)
                .Should()
                .Be(21.6M, "When you have three different books in you basket, you get 5% discount");
        }
    }

    [TestFixture]
    public class When_I_Checkout_With_Four_Different_Books
    {
        [TestCase(BookTitle.TitleOne, BookTitle.TitleTwo, BookTitle.TitleThree, BookTitle.TitleFour)]
        [TestCase(BookTitle.TitleOne, BookTitle.TitleThree, BookTitle.TitleFour, BookTitle.TitleFive)]
        [TestCase(BookTitle.TitleTwo, BookTitle.TitleOne, BookTitle.TitleFive, BookTitle.TitleFour)]
        public void Then_I_Get_5_Percent_Discount(BookTitle firstBookTitle, BookTitle secondBookTitle,
            BookTitle thirdBookTitle, BookTitle fourthBookTitle)
        {
            var potterCalculator = new PotterCalculator();
            var bookList = new List<BookTitle> {firstBookTitle, secondBookTitle, thirdBookTitle, fourthBookTitle};

            Assert.That(potterCalculator.Calculate(bookList), Is.EqualTo(25.6M));

            potterCalculator.Calculate(bookList)
                .Should()
                .Be(25.6M, "When you have four different books in you basket, you get 5% discount");
        }
    }

    [TestFixture]
    public class When_I_Checkout_With_Five_Different_Books
    {
        [TestCase(BookTitle.TitleOne, BookTitle.TitleTwo, BookTitle.TitleThree, BookTitle.TitleFour, BookTitle.TitleFive
            )]
        public void Then_I_Get_5_Percent_Discount(BookTitle firstBookTitle, BookTitle secondBookTitle,
            BookTitle thirdBookTitle, BookTitle fourthBookTitle,
            BookTitle fifthBookTitle)
        {
            var potterCalculator = new PotterCalculator();
            var bookList = new List<BookTitle>
            {
                firstBookTitle,
                secondBookTitle,
                thirdBookTitle,
                BookTitle.TitleFour,
                BookTitle.TitleFive
            };

            Assert.That(potterCalculator.Calculate(bookList), Is.EqualTo(30M));

            potterCalculator.Calculate(bookList)
                .Should()
                .Be(30M, "When you have four different books in you basket, you get 5% discount");
        }
    }

    [TestFixture]
    public class When_I_Checkout_With_Two_Same_And_One_Different_Books
    {
        [TestCase(BookTitle.TitleOne, BookTitle.TitleOne, BookTitle.TitleTwo)]
        public void Then_I_Get_5_Percent_Discount(BookTitle firstBookTitle, BookTitle secondBookTitle,
            BookTitle thirdBookTitle)
        {
            var potterCalculator = new PotterCalculator();
            var bookList = new List<BookTitle> {firstBookTitle, secondBookTitle, thirdBookTitle};

            Assert.That(potterCalculator.Calculate(bookList), Is.EqualTo(23.2M));
            potterCalculator.Calculate(bookList)
                .Should()
                .Be(23.2M,
                    "When you have 2 same books in you basket and one different, you get 5% discount on two books and no discount on one book");
        }
    }

    [TestFixture]
    public class When_I_Checkout_With_Multiple_Duplicate_Books
    {
        [Test]
        public void Then_I_Get_Discounts_Accordingly()
        {
            var potterCalculator = new PotterCalculator();
            var bookList = new List<BookTitle> {BookTitle.TitleOne, BookTitle.TitleTwo,BookTitle.TitleThree, BookTitle.TitleOne, BookTitle.TitleTwo, BookTitle.TitleThree, BookTitle.TitleFour, BookTitle.TitleFive};

            potterCalculator.Calculate(bookList).Should().Be(54M);
        }
    }
}