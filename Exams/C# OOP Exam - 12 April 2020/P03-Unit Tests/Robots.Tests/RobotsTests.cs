namespace Robots.Tests
{
    using NUnit.Framework;
    using System;

    public class RobotsTests
    {
        private Robot robot;
        private RobotManager robotManager;
        [SetUp]
        public void SetUp()
        {
            this.robot = new Robot("Pesho", 20);
            this.robotManager = new RobotManager(3);
        }
        [Test]
        public void RobotShouldInitializeCorrectly()
        {
            Assert.AreEqual("Pesho", this.robot.Name);
            Assert.AreEqual(20, this.robot.MaximumBattery);
            Assert.AreEqual(20, this.robot.Battery);

        }
        [Test]
        public void RobotManagerInitializesCorrectly()
        {
            Assert.AreEqual(3, this.robotManager.Capacity);
            Assert.AreEqual(0, this.robotManager.Count);

        }
        [Test]
        public void RobotManagerShouldThrowExceptionWhenInvalidCapacity()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                RobotManager newRobotManager = new RobotManager(-1);
            });
        }
        [Test]
        public void AddShouldWorkProperly()
        {
            this.robotManager.Add(this.robot);
            Assert.AreEqual(1, this.robotManager.Count);
        }
        [Test]
        public void AddShouldThrowExceptionWhenRobotManagerFull()
        {
            this.robotManager.Add(this.robot);
            Robot secRob = new Robot("Ivan", 100);
            Robot thirdRob = new Robot("Pencho", 80);
            this.robotManager.Add(secRob);
            this.robotManager.Add(thirdRob);
            Robot forthRob = new Robot("Misho", 120);
            Assert.Throws<InvalidOperationException>(() =>
            {
                this.robotManager.Add(forthRob);
            });

        }

        [Test]
        public void AddShouldThrowExceptionWhenRobotAlredyExists()
        {
            this.robotManager.Add(this.robot);
            Assert.Throws<InvalidOperationException>(() =>
            {
                this.robotManager.Add(this.robot);
            });
        }
        [Test]
        public void RemoveShouldWorkProperly()
        {
            this.robotManager.Add(this.robot);
            this.robotManager.Remove("Pesho");
            Assert.AreEqual(0, this.robotManager.Count);
        }
        [Test]
        public void RobotShouldThrowExceptionWhenNameDoesNotExist()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                this.robotManager.Remove("Pesho");

            });

        }
        [Test]
        public void WorkShouldWorkProperly()
        {
            this.robotManager.Add(this.robot);
            this.robotManager.Work("Pesho", "wash", 10);
            Assert.AreEqual(10, this.robot.Battery);
        }
        [Test]
        public void WorkShouldThrowExceptionWhenNameDoesNotExist()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                this.robotManager.Work("Pesho", "wash", 10);

            });
        }
        [Test]
        public void WorkShouldThrowExceptionWhenRobotDoesNotHaveEnoughBattery()
        {
            this.robotManager.Add(this.robot);

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.robotManager.Work("Pesho", "wash", 60);

            });
        }
        [Test]
        public void ChargeShouldThrowExceptionWhenNameDoesNotExist()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                this.robotManager.Charge("Pesho");

            });
        }
        [Test]
        public void ChargeShouldworkProperly()
        {
            this.robotManager.Add(this.robot);
            this.robotManager.Work("Pesho", "wash", 10);
            this.robotManager.Charge("Pesho");
            Assert.AreEqual(20, this.robot.Battery);
        }
    }
}
