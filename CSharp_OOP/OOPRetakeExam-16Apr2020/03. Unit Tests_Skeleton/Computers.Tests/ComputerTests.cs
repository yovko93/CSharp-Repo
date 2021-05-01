namespace Computers.Tests
{
    using NUnit.Framework;
    using System;
    using System.Linq;

    public class ComputerTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ConstructorShouldSetTheNameProperty()
        {
            Computer comp = new Computer("Lenovo");

            string expectedName = "Lenovo";
            string actualName = comp.Name;

            Assert.AreEqual(expectedName, actualName);
        }

        [Test]
        public void ConstructorShouldCreateNewList()
        {
            Computer comp = new Computer("Lenovo");

            Assert.IsEmpty(comp.Parts);
        }

        [Test]
        [TestCase(" ")]
        [TestCase(null)]
        public void NamePropertyShouldThrowExceptionIfIsInvalid(string name)
        {
            Assert.Throws<ArgumentNullException>(() =>
           new Computer(name) );
        }

        [Test]
        public void PartsPropertyShouldAddTwoParts()
        {
            Computer comp = new Computer("Lenovo");

            comp.AddPart(new Part("part1", 10));
            comp.AddPart(new Part("part2", 10));


            Assert.AreEqual(2, comp.Parts.Count);
        }

        [Test]
        public void TotalPriceShouldReturnCorrectResult()
        {
            Computer comp = new Computer("Lenovo");

            comp.AddPart(new Part("part1", 10));
            comp.AddPart(new Part("part2", 10));


            Assert.AreEqual(20, comp.TotalPrice);
        }

        [Test]
        public void AddPartShouldThrowExceptionWhenPartIsNull()
        {
            Computer comp = new Computer("Lenovo");
            Part part = null;

            Assert.Throws<InvalidOperationException>(() =>
            comp.AddPart(part));
        }

        [Test]
        public void AddPartShouldWorkProperly()
        {
            Computer comp = new Computer("Lenovo");

            comp.AddPart(new Part("part1", 10));

            var actualPart = comp.Parts.FirstOrDefault(x => x.Name == "part1");

            Assert.IsNotNull(actualPart);
            Assert.AreEqual("part1", actualPart.Name);

        }

        [Test]
        public void RemovePartShouldRemoveSuccessfull()
        {
            Computer comp = new Computer("Lenovo");

            comp.AddPart(new Part("part1", 10));
            comp.AddPart(new Part("part2223", 10));


            var partToRemove = comp.Parts.FirstOrDefault(x => x.Name == "part2223");
            comp.RemovePart(partToRemove);

            Assert.AreEqual(1, comp.Parts.Count);
        }

        [Test]
        public void RemovePartShouldReturnTrue()
        {
            Computer comp = new Computer("Lenovo");

            comp.AddPart(new Part("part1", 10));
            comp.AddPart(new Part("part2223", 10));


            var partToRemove = comp.Parts.FirstOrDefault(x => x.Name == "part2223");
            bool actualRes = comp.RemovePart(partToRemove);

            Assert.IsTrue(actualRes);
        }

        [Test]
        public void RemovePartShouldReturnFalse()
        {
            Computer comp = new Computer("Lenovo");

            comp.AddPart(new Part("part1", 10));

            Part part2 = new Part("part22", 20);

            bool actualRes = comp.RemovePart(part2);

            Assert.IsFalse(actualRes);
        }

        [Test]
        public void GetPartShouldReturnPart()
        {
            Computer comp = new Computer("Lenovo");

            Part part = new Part("part1", 10);

            comp.AddPart(part);

            Part actualPart = comp.GetPart("part1");

            Assert.IsNotNull(actualPart);
        }

        [Test]
        public void GetPartShouldReturnNull()
        {
            Computer comp = new Computer("Lenovo");

            Part part = new Part("part1", 10);

            comp.AddPart(part);

           // Part actualPart = comp.GetPart("part4");

            Assert.IsNull(comp.GetPart("part4"));
        }
    }
}