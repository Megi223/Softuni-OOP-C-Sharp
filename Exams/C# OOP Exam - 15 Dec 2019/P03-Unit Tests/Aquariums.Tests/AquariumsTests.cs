namespace Aquariums.Tests
{
    using NUnit.Framework;
    using System;

    public class AquariumsTests
    {
        private Aquarium aquarium;
        [SetUp]
        public void SetUp()
        {
            aquarium = new Aquarium("FishWorld", 2);

        }


        [Test]
        public void FishIsInstantiatedCorrectly()
        {
            Fish fish = new Fish("Nemo");
            Assert.AreEqual("Nemo", fish.Name);
            Assert.AreEqual(true, fish.Available);

        }
        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void AquariumShouldThrowExceptionWhenNameNull(string name)
        {
            
            Assert.Throws<ArgumentNullException>(() =>
            {
                Aquarium aquarium = new Aquarium(name, 20);
            }, "Invalid aquarium name!");
        }
        [Test]
        [TestCase(-1)]
        public void AquariumShouldThrowExceptionWhenInvalidCapacity(int capacity)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Aquarium aquarium = new Aquarium("FishWorld", capacity);
            }, "Invalid aquarium capacity!");
        }
        [Test]
        [TestCase(0)]
        [TestCase(20)]

        public void AquariumShouldInstantiateProperly(int capacity)
        {
            Aquarium aquarium = new Aquarium("FishWorld", capacity);
            Assert.AreEqual("FishWorld", aquarium.Name);
            Assert.AreEqual(capacity, aquarium.Capacity);
            Assert.AreEqual(0, aquarium.Count);

        }
        [Test]
        public void AddShouldWorkProperly()
        {
            aquarium.Add(new Fish("Mat"));
            aquarium.Add(new Fish("Nemo"));
            int expectedCount = 2;
            Assert.AreEqual(expectedCount, aquarium.Count);
        }
        [Test]
        public void AddShouldThrowExceptionWhenAquariumFull()
        {
            aquarium.Add(new Fish("Mat"));
            aquarium.Add(new Fish("Nemo"));
            Assert.Throws<InvalidOperationException>(() =>
            {
                aquarium.Add(new Fish("Jack"));
            }, "Aquarium is full!");
        }
        [Test]
        public void RemoveShouldWorkProperly()
        {
            aquarium.Add(new Fish("Mat"));
            aquarium.RemoveFish("Mat");
            Assert.AreEqual(0, this.aquarium.Count);
        }
        [Test]
        public void RemoveShouldThrowExceptionWhenTryingToRemveNonExistentFish()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                aquarium.RemoveFish("Mat");
            }, $"Fish with the name Mat doesn't exist!");
        }

        [Test]
        public void SellShouldWorkProperly()
        {
            Fish fish = new Fish("Mat");
            aquarium.Add(fish);
            Fish soldFish=aquarium.SellFish("Mat");
            Assert.AreEqual(fish, soldFish);
            Assert.AreEqual(false, soldFish.Available);
        }

        [Test]
        public void SellThrowsExceptionWhenFishDoesNotExist()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                
                Fish soldFish = aquarium.SellFish("Mat");
            }, $"Fish with the name Mat doesn't exist!");
        }

        [Test]
        public void ReportShouldWorkProperlyWithOneFish()
        {
            Fish fish = new Fish("Mat");
            aquarium.Add(fish);
            string expectedResult = $"Fish available at FishWorld: Mat";
            string actualResult = aquarium.Report();
            Assert.AreEqual(expectedResult, actualResult);
        }
        [Test]
        public void ReportShouldWorkProperlyWithTwoFish()
        {
            Fish fish = new Fish("Mat");
            Fish secondFish = new Fish("George");
            aquarium.Add(fish);
            aquarium.Add(secondFish);
            string expectedResult = $"Fish available at FishWorld: Mat, George";
            string actualResult = aquarium.Report();
            Assert.AreEqual(expectedResult, actualResult);


        }

    }
}
