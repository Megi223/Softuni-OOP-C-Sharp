namespace Presents.Tests
{
    using NUnit.Framework;
    using System;
    using Presents;

    public class PresentsTests
    {
        Bag bag;

        [SetUp]
        public void SetUp()
        {
           bag = new Bag();

        }

        [Test]
        public void PresentIsInstantiatedCorrectly()
        {
            Present present = new Present("Train", 50);
            Assert.AreEqual("Train", present.Name);
            Assert.AreEqual(50, present.Magic);
        }

        [Test]
        public void BagIsInstantiatedProperly()
        {
            
            Assert.AreEqual(0, bag.GetPresents().Count);
        }
        [Test]
        public void CreateShouldThrowExceptionWhenPresentNull()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                bag.Create(null);
            }, "Present is null");
        }
        [Test]
        public void CreateShouldThrowExceptionWhenPresentAlreadyExists()
        {
            Present present = new Present("Train", 50);
            bag.Create(present);
            Assert.Throws<InvalidOperationException>(() =>
            {
                bag.Create(present);
            }, "This present already exists!");
        }

        [Test]
        public void CreateWorksProperly()
        {
            bag.Create(new Present("Train", 50));
            int expectedCount = 1;
            int actualCount = bag.GetPresents().Count;
            Assert.AreEqual(expectedCount, actualCount);
        }
        [Test]
        public void CreatesReturnsCorrectMessage()
        {
            
            string expectedMessage = "Successfully added present Train.";
            Assert.AreEqual(expectedMessage, bag.Create(new Present("Train", 50)));
        }
        [Test]
        public void RemoveShouldReturnTrueWhenProductIsRemoved()
        {
            Present present = new Present("Train", 50);
            bag.Create(present);
            bool expectedResult = true;
            bool actualResult = bag.Remove(present);
            Assert.AreEqual(expectedResult, actualResult);
        }
        
        [Test]
        public void RemoveShouldReturnFalseWhenProductIsNotRemoved()
        {
            Present present = new Present("Train", 50);
            
            bool expectedResult = false;
            bool actualResult = bag.Remove(present);
            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void GetPresentWithLeastMagicShouldReturnCorrectPresent()
        {
            Present presentOne = new Present("Train", 50);
            Present presentTwo = new Present("TeddyBear", 100);
            bag.Create(presentOne);
            bag.Create(presentTwo);

           
            Present actualPresent = bag.GetPresentWithLeastMagic();
            Assert.AreEqual(presentOne, actualPresent);


        }
        [Test]
        

        public void GetPresentShouldWorkProperly()
        {
            Present presentOne = new Present("Train", 50);
            Present presentTwo = new Present("TeddyBear", 100);
            bag.Create(presentOne);
            bag.Create(presentTwo);

            Present actualPresent=bag.GetPresent("Train");
            Assert.AreEqual(presentOne, actualPresent);
        }
        [Test]


        public void GetPresentShouldWorkProperlyWhenNameNull()
        {
            Present presentOne = new Present("Train", 50);
            Present presentTwo = new Present("TeddyBear", 100);
            bag.Create(presentOne);
            bag.Create(presentTwo);

            Present actualPresent = bag.GetPresent(null);
            Assert.AreEqual(null, actualPresent);
        }
    }
}
