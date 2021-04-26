using NUnit.Framework;
using System;

using ExtendedDatabase;

namespace Tests
{
    public class ExtendedDatabaseTests
    {
        private Person[] people;
        private ExtendedDatabase.ExtendedDatabase database;

        [SetUp]
        public void Setup()
        {
            people = new Person[]
           { new Person(0,"Pesho"),
              new Person (1,"Misho"),
              new Person (2,"Gosho"),
              new Person (3,"Mimi"),
              new Person (4,"Rosana"),
              new Person(5,"Peshito"),
              new Person (6,"Mishto"),
              new Person (7,"Goshko"),
              new Person (8,"Mimito"),
              new Person (9, "Roxana"),
              new Person(10,"Pepi"),
              new Person (11,"Mishko"),
              new Person (12,"Gosheto"),
              new Person (13,"Mitko"),
              new Person (14, "Roximira"),
              new Person (15, "Nikolina"),
           };

            database = new ExtendedDatabase.ExtendedDatabase(people);
        }

        [Test]
        public void ConstructorShouldBeInitializedWith16People()
        {
            people = new Person[]
          { new Person(12478,"Pesho"),
              new Person (32092,"Misho"),
              new Person (43589,"Gosho"),
              new Person (49109,"Mimi"),
              new Person (9820989,"Rosana"),
              new Person(12345,"Peshito"),
              new Person (32098,"Mishto"),
              new Person (43356,"Goshko"),
              new Person (492098,"Mimito"),
              new Person (9836749, "Roxana"),
              new Person(123490,"Pepi"),
              new Person (32078,"Mishko"),
              new Person (433590,"Gosheto"),
              new Person (492678,"Mitko"),
              new Person (9836745, "Roximira"),
              new Person (8963790, "Nikolina"),
          };

            database = new ExtendedDatabase.ExtendedDatabase(people);

            var expectedResult = 16;
            var actualResult = database.Count;

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void AddRangeThrowExceptionIfPeopleAreMoreThan16()
        {
            people = new Person[]
           { new Person(12478,"Pesho"),
              new Person (32092,"Misho"),
              new Person (43589,"Gosho"),
              new Person (49109,"Mimi"),
              new Person (9820989,"Rosana"),
              new Person(12345,"Peshito"),
              new Person (32098,"Mishto"),
              new Person (43356,"Goshko"),
              new Person (492098,"Mimito"),
              new Person (9836749, "Roxana"),
              new Person(123490,"Pepi"),
              new Person (32078,"Mishko"),
              new Person (433590,"Gosheto"),
              new Person (492678,"Mitko"),
              new Person (9836745, "Roximira"),
              new Person (8963790, "Nikolina"),
              new Person (432516, "Maxi")
           };

            Assert.That(() =>
             new ExtendedDatabase.ExtendedDatabase(people), Throws.ArgumentException);
        }

        [Test]
        public void AddShouldThrowExceptionIfCountIsMoreThan16()
        {
            Person newPerson = new Person(1234235, "Roktyi");

            Assert.Throws<InvalidOperationException>(() =>
            database.Add(newPerson));
        }

        [Test]
        [TestCase(1242523, "Pepi")]
        [TestCase(4, "Yovko")]
        public void AddShouldThrowExceptionIfThereIsAlreadyPersonWithThatNameOrId(long id, string name)
        {
            //Arrange
            Person newPerson = new Person(id, name);

            //Act / Assert
            database.Remove();
            Assert.Throws<InvalidOperationException>(() =>
            database.Add(newPerson));
        }


        /// <summary>
        /// ///////    
        /// </summary>
        //[Test]
        //public void AddOperationShouldAddElementAtNextFreeCell()
        //{
        //    people = new Person[]
        //    {
        //        new Person(0,"Pesho"),
        //      new Person (1,"Misho"),
        //    };

        //    var actualDatabase = new ExtendedDatabase.ExtendedDatabase(people);
        //    var expectedDatabase = new ExtendedDatabase.ExtendedDatabase();



        //    Person newPerson = new Person(0, "Pesho");
        //    expectedDatabase.Add(newPerson);
        //    Person newPerson2 = new Person(1, "Misho");
        //    expectedDatabase.Add(newPerson2);

        //    Assert.AreEqual(expectedDatabase, actualDatabase);
        //}

        [Test]
        public void RemoveShouldThrowExceptionIfThereIsNoPeople()
        {
            //Arrange
            database = new ExtendedDatabase.ExtendedDatabase();

            //Act / Assert
            Assert.Throws<InvalidOperationException>(() =>
            database.Remove());
        }

        [Test]
        public void RemoveShouldRemoveTheLastElementFromTheCollection()
        {
            //Arrange / Act
            database.Remove();

            //Assert
            var expectedCount = 15;
            var actualCount = database.Count;

            Assert.That(() => database.FindById(15), Throws.InvalidOperationException);
            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        [TestCase("")]
        [TestCase(null)]
        //[TestCase(" ")]
        public void FindByUsernameShouldThrowExceptionIfNameIsNullOrEmpty(string name)
        {
            Assert.Throws<ArgumentNullException>(() =>
            database.FindByUsername(name));
        }

        [Test]
        [TestCase("Magda")]
        public void FindByUsernameShouldThrowExceptionIfNameIsNotExist(string name)
        {
            Assert.Throws<InvalidOperationException>(() =>
            database.FindByUsername(name));
        }

        [Test]
        public void ArgumentsAreCaseSensitiveInFindPersonByName()
        {
            Person findPerson = database.FindById(10);
            string name = findPerson.UserName.ToLower();

            Assert.That(() => database.FindByUsername(name), Throws.InvalidOperationException);
        }

        [Test]
        [TestCase("Pesho")]
        public void FindByUsernameShouldReturnPerson(string name)
        {
            Person expectedPerson = database.FindById(0);

            Person actualPerson = database.FindByUsername(name);

            Assert.AreEqual(expectedPerson, actualPerson);
        }

        [Test]
        [TestCase(-12421)]
        public void FindByIdShouldThrowExceptionWhenIdIsNegative(long id)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            database.FindById(id));
        }

        [Test]
        [TestCase(2432421)]
        public void FindByIdShouldThrowExceptionWhenIdIsFalse(long id)
        {
            Assert.Throws<InvalidOperationException>(() =>
            database.FindById(id));
        }

        [Test]
        [TestCase(0)]
        public void FindByIdShouldReturnThePersonWithId(long id)
        {
            Person expectedPerson = database.FindByUsername("Pesho");

            Person actualPerson = database.FindById(id);

            Assert.AreEqual(expectedPerson, actualPerson);
        }
    }
}