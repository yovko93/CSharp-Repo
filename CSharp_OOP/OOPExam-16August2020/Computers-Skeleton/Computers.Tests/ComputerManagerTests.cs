using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Computers.Tests
{
    public class Tests
    {
        //private ComputerManager computers;
        //Computer comp;

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void AddMethodShouldThrowExceptionIfNullOrDuplicateDataIsPassed()
        {
            ComputerManager computerManager = new ComputerManager();
            Computer comp = new Computer("Test", "Model", 100);

            Assert.Throws<ArgumentNullException>(() =>
            computerManager.AddComputer(null));


            computerManager.AddComputer(comp);
            Assert.Throws<ArgumentException>(() =>
            computerManager.AddComputer(comp));
        }

        [Test]
        public void AddComputerShouldAddComputerCorrectly()
        {
            ComputerManager computerManager = new ComputerManager();

            var comp = new Computer("Test", "Model", 100);
            computerManager.AddComputer(comp);

            Assert.AreEqual(1, computerManager.Count);
            Assert.AreEqual(1, computerManager.Computers.Count);
        }

        [Test]
        public void GetComputerShouldThrowExceptionOnInvalidData()
        {
            ComputerManager computerManager = new ComputerManager();

            Assert.Throws<ArgumentNullException>(() =>
            computerManager.GetComputer("Test", null));
            Assert.Throws<ArgumentNullException>(() =>
            computerManager.GetComputer(null, "test"));
            Assert.Throws<ArgumentException>(() =>
            computerManager.GetComputer("Test", "Test"));
        }

        [Test]
        public void GetComputerShouldWorkAsExpected()
        {
            ComputerManager computerManager = new ComputerManager();
            Computer comp = new Computer("Test", "Model", 100);
            computerManager.AddComputer(comp);

            var computerFromCompManager = computerManager.GetComputer("Test", "Model");

            Assert.AreEqual(comp, computerFromCompManager);
        }

        [Test]
        public void RemoveComputerShouldWorkAsExpected()
        {
            ComputerManager computerManager = new ComputerManager();
            Computer comp = new Computer("Test", "Model", 100);
            computerManager.AddComputer(comp);

            var computerFromCompManager = computerManager.RemoveComputer("Test", "Model");

            Assert.AreEqual(comp, computerFromCompManager);
            Assert.AreEqual(0, computerManager.Count);
            Assert.AreEqual(0, computerManager.Computers.Count);
        }

        [Test]
        public void GetComputersByManufacturerShouldWorkAsExpected()
        {
            ComputerManager computerManager = new ComputerManager();
            Computer comp = new Computer("Test", "Model", 100);
            Computer comp2 = new Computer("Test", "TestModel", 100);
            Computer comp3 = new Computer("Test232", "TestModel", 100);

            computerManager.AddComputer(comp);
            computerManager.AddComputer(comp2);
            computerManager.AddComputer(comp3);

            var computerFromCompManager = computerManager.GetComputersByManufacturer("Test");

            CollectionAssert.Contains(computerFromCompManager, comp);
            CollectionAssert.Contains(computerFromCompManager, comp2);
            CollectionAssert.DoesNotContain(computerFromCompManager, comp3);
        }

        [Test]
        public void RemoveComputerShouldThrowException()
        {
            ComputerManager computerManager = new ComputerManager();
            Computer comp = new Computer("Test", "Model", 100);
            computerManager.AddComputer(comp);

            Assert.Throws<ArgumentNullException>(() =>
            computerManager.RemoveComputer(null, "Model"));

            Assert.Throws<ArgumentNullException>(() =>
            computerManager.RemoveComputer("Test", null));


            Assert.Throws<ArgumentException>(() =>
            computerManager.RemoveComputer("Manufact", "Test"));
        }

    }
}