namespace Robots.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class RobotsTests
    {
        private Robot robot;
        private RobotManager robotManager;

        [SetUp]
        public void Setup()
        {
            robot = new Robot("Rob", 100);
            robotManager = new RobotManager(2);
        }

        [Test]
        public void WhenRobotIsCreated_PropertiesShouldBeSet()
        {
            Assert.AreEqual("Rob", robot.Name);
            Assert.AreEqual(100, robot.MaximumBattery);
            Assert.AreEqual(100, robot.Battery);
        }

        [Test]
        public void WhenRobotManagerIsCreated_CapacityShouldBeSet()
        {
            Assert.AreEqual(2, robotManager.Capacity);
        }

        [Test]
        public void RobotManagerShouldThrowExceptionWhenCapacityIsBelowZero()
        {
            Assert.Throws<ArgumentException>(() =>
             robotManager = new RobotManager(-10));
        }

        [Test]
        public void AddShouldThrowException()
        {
            robotManager.Add(robot);

            Assert.Throws<InvalidOperationException>(() =>
            robotManager.Add(robot));

            robotManager.Add(new Robot("Test", 10));

            Assert.Throws<InvalidOperationException>(() =>
            robotManager.Add(new Robot("gosho", 10)));
        }

        [Test]
        public void AddShouldWorkAsExpected()
        {
            robotManager.Add(robot);

            Assert.AreEqual(1, robotManager.Count);
        }

        [Test]
        public void RemoveShouldThrowException()
        {
            Assert.Throws<InvalidOperationException>(() =>
            robotManager.Remove("Test"));
        }

        [Test]
        public void RemoveShouldWorkAsExpected()
        {
            robotManager.Add(robot);

            robotManager.Remove("Rob");

            Assert.AreEqual(0, robotManager.Count);
        }

        [Test]
        public void WorkShouldThrowException()
        {
            Assert.Throws<InvalidOperationException>(() =>
            robotManager.Work("Pesho", "job", 10));

            robotManager.Add(robot);

            Assert.Throws<InvalidOperationException>(() =>
            robotManager.Work("Rob", "job", 200));
        }

        [Test]
        public void WorkShouldWorkAsExpected()
        {
            robotManager.Add(robot);

            robotManager.Work("Rob", "job", 10);

            Assert.AreEqual(90, robot.Battery);
        }

        [Test]
        public void ChargeShouldThrowException()
        {
            Assert.Throws<InvalidOperationException>(() =>
            robotManager.Charge("Nqma me"));
        }

        [Test]
        public void ChargeShouldWorkAsExpected()
        {
            robotManager.Add(robot);
            robotManager.Work("Rob", "job", 10);
            robotManager.Charge("Rob");

            Assert.AreEqual(100, robot.Battery);
        }
    }
}
