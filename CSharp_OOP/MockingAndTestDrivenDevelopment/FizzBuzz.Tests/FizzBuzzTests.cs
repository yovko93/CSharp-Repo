using FizzBuzz.Contracts;
using FizzBuzz.Tests.Fakes;
using Moq;
using NUnit.Framework;

namespace FizzBuzz.Tests
{
    public class Tests
    {
        //private FakeConsoleWriter writer;
        private FizzBuzz fizzBuzz;
        private string result;

        // Mocking
        Mock<IWriter> writer;

        [SetUp]
        public void Setup()
        {
            //writer = new FakeConsoleWriter();
            //fizzBuzz = new FizzBuzz(writer);

            writer = new Mock<IWriter>();
            writer.Setup(w => w.WriteLine(It.IsAny<string>()))
                .Callback<string>(i => result += i);
            fizzBuzz = new FizzBuzz(writer.Object);
            result = "";
        }

        [Test]
        public void GivenFizzBuzzWhenNumbersAre1To2ThenResultShouldBeCorrect()
        {
            //Mock<IWriter> writer = new Mock<IWriter>();
            //writer.Setup()

            fizzBuzz.PrintNumbers(1,2);

            Assert.AreEqual("12", result);
        }

        [Test]
        public void GivenFizzBuzzWhenNumbersAre1To3ThenResultShouldBeCorrect()
        {
            fizzBuzz.PrintNumbers(1, 3);

            Assert.AreEqual("12fizz", result);
        }

        [Test]
        public void GivenFizzBuzzWhenNumbersAre4To6ThenResultShouldBeCorrect()
        {
            fizzBuzz.PrintNumbers(4, 6);

            Assert.AreEqual("4buzzfizz", result);
        }

        [Test]
        public void GivenFizzBuzzWhenNumbersAre14To17ThenResultShouldBeCorrect()
        {
            fizzBuzz.PrintNumbers(14, 17);

            Assert.AreEqual("14fizzbuzz1617", result);
        }

        [Test]
        public void GivenFizzBuzzWhenNumbersAreMinus5To2ThenResultShouldBeCorrect()
        {
            fizzBuzz.PrintNumbers(-5, 2);

            Assert.AreEqual("12", result);
        }
    }
}