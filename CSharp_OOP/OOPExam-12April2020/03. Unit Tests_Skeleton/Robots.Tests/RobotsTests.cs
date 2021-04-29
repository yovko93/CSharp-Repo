namespace Robots.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class RobotsTests
    {
      
        [Test]
        public void ConstructorShouldWorkProperly()
        {
            var robotManager = new RobotManager(100);

            Assert.AreEqual(100, robotManager.Capacity);
        }

        [Test]
        public void CapacityShouldThrowExceptionWhenValueIsBelowZero()
        {
            Assert.Throws<ArgumentException>(() =>
           new RobotManager(-100));
        }

        [Test]
        public void RobotsCountShouldCountProperly()
        {
            var robotManager = new RobotManager(100);
            var robot = new Robot("Alex", 100);

            robotManager.Add(robot);

            Assert.AreEqual(1, robotManager.Count);
        }

        [Test]
        public void AddShouldThrowExceptionIfThereIsARobotWithThatName()
        {
            var robotManager = new RobotManager(100);
            var robot = new Robot("Alex", 100);

            robotManager.Add(robot);

            Assert.Throws<InvalidOperationException>(() =>
            robotManager.Add(robot));
        }

        [Test]
        public void AddShouldThrowExceptionWhenCapacityIsFull()
        {
            var robot = new Robot("Alex", 100);
            var robotManager = new RobotManager(1);
            
            robotManager.Add(robot);

            Assert.Throws<InvalidOperationException>(() =>
            robotManager.Add(robot));
        }

        [Test]
        public void RemoveShouldWorkProperly()
        {
            var robotManager = new RobotManager(1);
            var robot = new Robot("Alex", 100);

            robotManager.Add(robot);

            robotManager.Remove("Alex");

            Assert.AreEqual(0, robotManager.Count);
        }

        [Test]
        public void RemoveShouldThrowExceptionIfNameDoesntExist()
        {
            var robotManager = new RobotManager(10);

            Assert.Throws<InvalidOperationException>(() =>
            robotManager.Remove("Gsoho"));
        }

        [Test]
        public void WorkShouldDecreaseRobotBattery()
        {
            var robot = new Robot("Alex", 100);
            var robotManager = new RobotManager(1);
            robotManager.Add(robot);

            robotManager.Work("Alex", "Cleaning", 20);

            Assert.AreEqual(80, robot.Battery);
        }

        [Test]
        public void WorkShouldThrowExceptionIfInvalidRobot()
        {
            var robotManager = new RobotManager(1);

            Assert.Throws<InvalidOperationException>(() =>
            robotManager.Work("Pesho", "job", 10));
        }

        [Test]
        public void WorkShouldThrowExceptionWhenBatteryIsNotEnogh()
        {
            var robotManager = new RobotManager(1);
            var robot = new Robot("Alex", 10);
            robotManager.Add(robot);

            Assert.Throws<InvalidOperationException>(() =>
            robotManager.Work("Alex", "job", 50));
        }

        [Test]
        public void ChargeShouldWorkProperly()
        {
            var robotManager = new RobotManager(10);
            var robot = new Robot("Alex", 100);
            robotManager.Add(robot);

            robotManager.Work("Alex", "job", 50);
            robotManager.Charge("Alex");

            int expextedResult = 100;
            int actualResult = robot.Battery;

            Assert.AreEqual(expextedResult, actualResult);
        }

        [Test]
        public void ChargeShouldThrowExceptionForInvalidRobot()
        {
            var robotManager = new RobotManager(10);

            Assert.Throws<InvalidOperationException>(() =>
            robotManager.Charge("Gsoho"));
        }
    }
}
