using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using TheRace;

namespace TheRace.Tests
{
    public class RaceEntryTests
    {
        private UnitCar car;
        private UnitDriver driver;
        private RaceEntry raceEntry;
        private Dictionary<string, UnitDriver> driversDictionary;

        [SetUp]
        public void Setup()
        {
            this.raceEntry = new RaceEntry();
            this.car = new UnitCar("Model", 100, 2000);
            this.driver = new UnitDriver("Name", car);
            this.driversDictionary = new Dictionary<string, UnitDriver>();
        }

        [Test]
        public void AddDriverShouldThrowException()
        {
            Assert.Throws<InvalidOperationException>(() =>
            raceEntry.AddDriver(null));
        }

        [Test]
        public void AddDriverShouldThrowExceptionIfDriverExist()
        {
            raceEntry.AddDriver(driver);
            driversDictionary.Add(driver.Name, driver);

            Assert.Throws<InvalidOperationException>(() =>
            raceEntry.AddDriver(driver));
        }

        [Test]
        public void AddDriverShouldWorkProperly()
        {
            raceEntry.AddDriver(driver);
            driversDictionary.Add(driver.Name, driver);

            Assert.AreEqual(1, driversDictionary.Count);
        }

        [Test]
        public void AddDriverShouldReturnCorrectResult()
        {
            string expectedResult = $"Driver Name added in race.";
            string result = raceEntry.AddDriver(driver);

            Assert.AreEqual(expectedResult, result);
        }

        [Test]
        public void CalculateAverageHorsePowerShouldThrowException()
        {
            raceEntry.AddDriver(driver);
            driversDictionary.Add(driver.Name, driver);

            Assert.Throws<InvalidOperationException>(() =>
             raceEntry.CalculateAverageHorsePower());
        }

        [Test]
        public void CalculateAverageHorsePowerShouldWorkProperly()
        {
            raceEntry.AddDriver(driver);
            driversDictionary.Add(driver.Name, driver);

            raceEntry.AddDriver(new UnitDriver("Gosho", new UnitCar("car", 100, 2000)));

            double result = raceEntry.CalculateAverageHorsePower();
            double expectedResult = driversDictionary
                .Values
                .Select(x => x.Car.HorsePower)
                .Average();

            Assert.AreEqual(expectedResult, result);
        }
    }
}