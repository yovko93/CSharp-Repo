using CarManager;
using NUnit.Framework;
using System;

namespace Tests
{
    public class CarTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        [TestCase("VW", "GolF", 10, 100)]
        [TestCase("BMW", "3", 20, 200)]
        public void CarConstructorShouldSetAllDataCorrectly(
            string make,
            string model,
            double fuelConsumption,
            double fuelCapacity)
        {
            //Arrange /Act
            Car car = new Car(
                make: make,
                model: model,
                fuelConsumption: fuelConsumption,
                fuelCapacity: fuelCapacity);

            //Assert
            Assert.AreEqual(car.Make, make);
            Assert.AreEqual(car.Model, model);
            Assert.AreEqual(car.FuelConsumption, fuelConsumption);
            Assert.AreEqual(car.FuelCapacity, fuelCapacity);
            Assert.AreEqual(car.FuelAmount, 0);

        }

        [Test]
        [TestCase("")]
        [TestCase(null)]
        public void CarConstructorShouldThrowExceptionIfMakeIsNullOrEmpty(string make)
        {
            Assert.Throws<ArgumentException>(() =>
            new Car(make, "model", 10, 100));
        }

        [Test]
        [TestCase("")]
        [TestCase(null)]
        public void CarConstructorShouldThrowExceptionIfModelIsNullOrEmpty(string model)
        {
            Assert.Throws<ArgumentException>(() =>
            new Car("make", model, 10, 100));
        }

        [Test]
        [TestCase(0)]
        [TestCase(-30)]
        public void CarConstructorShouldThrowExceptionIfFuelConsumptionIsBelowOrEqualToZero(double fuelConsumption)
        {
            Assert.Throws<ArgumentException>(() =>
            new Car("make", "model", fuelConsumption, 100));
        }


        [Test]
        [TestCase(0)]
        [TestCase(-30)]
        public void CarConstructorShouldThrowExceptionIfFuelCapacityIsBelowOrEqualToZero(double fuelCapacity)
        {
            Assert.Throws<ArgumentException>(() =>
            new Car("make", "model", 10, fuelCapacity));
        }

        [Test]
        [TestCase(0)]
        [TestCase(-50)]
        public void RefuelShouldThrowExceptionWhenPassedValueIsBelowOrEqualToZero(double fuelToRefuel)
        {
            Car car = new Car("BMW", "3", 20, 100);

            Assert.Throws<ArgumentException>(() =>
            car.Refuel(fuelToRefuel));
        }


        [Test]
        [TestCase(100, 50, 50)]
        [TestCase(200, 350, 200)]
        public void RefuelShouldWorkAsExpected(double capacity, double fuelToRefuel, double expectedResult)
        {
            //Arrange
            Car car = new Car("BMW", "5", 10, capacity);

            //Act
            car.Refuel(fuelToRefuel);

            //Assert
            var actualResult = car.FuelAmount;

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        [TestCase(10, 10, 200)]
        [TestCase(15, 20, 300)]
        [TestCase(15, 1, 30)]
        public void DriveShouldThrowExceptionIfFuelNeededIsMoreThanFuelAmount(double fuelConsumption, double refuel, double distance)
        {
            //Arrange
            Car car = new Car("make", "model", fuelConsumption, 100);
            car.Refuel(refuel);

            //Act 
            // Assert
            Assert.Throws<InvalidOperationException>(() =>
            car.Drive(distance));
        }

        [Test]
        [TestCase(10, 100, 500, 50)]
        [TestCase(10, 100, 50, 95)]
        public void DriveShouldReduceFuelBasedOnDrivenKm(double fuelConsumption, double fuelToRefuel, double km, double fuelAmountLeft)
        {
            //Arrange
            Car car = new Car("VW", "3", fuelConsumption, 100);
            car.Refuel(fuelToRefuel);

            //Act
            car.Drive(km);

            //Assert
            var expectedResult = fuelAmountLeft;
            var actualResult = car.FuelAmount;

            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}