using NUnit.Framework;
using System;
using System.Linq;


namespace Tests
{
    public class DatabaseTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ConstructorShouldBeInitializedWith16Elements()
        {
            //Arrange
            int[] numbers = Enumerable.Range(1, 16).ToArray();
            Database.Database database = new Database.Database(numbers);

            //Act
            var expectedResult = 16;
            var actualResult = database.Count;

            //Assert

            Assert.AreEqual(expectedResult, actualResult);

        }

        //[Test]
        //public void ConstructorShouldThrowExceptionIfThereAreNot16Elements()
        //{
        //    //TODO:

        //    //Arrange
        //    int[] numbers = Enumerable.Range(1, 10).ToArray();
        //    Database.Database database = new Database.Database(numbers);

        //    //Act
        //    var expectedResult = 10;
        //    var actualResult = database.Count;

        //    //Assert

        //    Assert.AreEqual(expectedResult, actualResult);
        //}

        [Test]
        public void AddOperationShouldAddElementAtNextFreeCell()
        {
            //Arrange
            int[] numbers = Enumerable.Range(1, 10).ToArray();
            Database.Database database = new Database.Database(numbers);

            //Act
            database.Add(5);
            var allElements = database.Fetch();

            //Assert
            var expectedResult = 5;
            var actualResult = allElements[10];

            var expectedCount = 11;
            var actualCount = database.Count;

            Assert.AreEqual(expectedCount, actualCount);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void AddOperationShouldThrowExceptionIfElementsAreAbove16()
        {
            //Arrange
            int[] numbers = Enumerable.Range(1, 16).ToArray();
            Database.Database database = new Database.Database(numbers);

            //Act - Assert
            Assert.Throws<InvalidOperationException>(() =>
            database.Add(10));
        }

        [Test]
        public void RemoveOperationShouldRemoveOnlyTheElementAtTheLastIndex()
        {
            //Arrange
            int[] numbers = Enumerable.Range(1, 10).ToArray();
            Database.Database database = new Database.Database(numbers);

            //Act
            database.Remove();

            //Assert
            var expectedResult = 9;
            var actualValue = database.Fetch()[8];

            var expectedCount = 9;
            var actualCount = database.Count;

            Assert.AreEqual(expectedCount, actualCount);
            Assert.AreEqual(expectedResult, actualValue);
        }

        [Test]
        public void RemoveOperationShouldThrowExceptionIfDatabaseIsEmpty()
        {
            //Arrange
            Database.Database database = new Database.Database();

            //Act Assert
            Assert.Throws<InvalidOperationException>(() =>
            database.Remove());
        }

        [Test]
        public void FetchShouldReturnAllElements()
        {
            //Arrange
            int[] numbers = Enumerable.Range(1, 5).ToArray();
            Database.Database database = new Database.Database(numbers);

            //Act
            var allItems = database.Fetch();

            //Assert
            int[] expectedValue = { 1, 2, 3, 4, 5 };

            CollectionAssert.AreEqual(expectedValue, allItems);
        }
    }
}