namespace Telecom.Tests
{
    using NUnit.Framework;
    using System;

    public class Tests
    {
        private Phone phone;
        [SetUp]
        public void SetUp()
        {
            phone = new Phone("Iphone", "5S");

        }
        [Test]
        public void PhoneInitializesCorrectly()
        {
            Assert.AreEqual("Iphone", this.phone.Make);
            Assert.AreEqual("5S", this.phone.Model);
            Assert.AreEqual(0, this.phone.Count);

        }
        [Test]
        [TestCase(null)]
        [TestCase("")]

        public void PhoneThrowsExceptionWhenMakeInvalid(string make)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Phone invalidPhone = new Phone(make, "5s");
            });
            
        }
        [Test]
        [TestCase(null)]
        [TestCase("")]

        public void PhoneThrowsExceptionWhenModelInvalid(string model)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Phone invalidPhone = new Phone("Iphone", model);
            });

        }
        [Test]
        public void PhoneAddsProperly()
        {
            phone.AddContact("Pesho", "1234567890");
            Assert.AreEqual(1, this.phone.Count);
        }
        [Test]
        public void PhoneThrowsExceptionWhenUserAlreadyExists()
        {
            phone.AddContact("Pesho", "1234567890");
            Assert.Throws<InvalidOperationException>(() =>
            {
                phone.AddContact("Pesho", "123456");

            });
            
        }
        [Test]
        public void CallWorksProperly()
        {
            phone.AddContact("Pesho", "1234567890");
            string actualRes=phone.Call("Pesho");
            string expectedRes= $"Calling Pesho - 1234567890...";
            Assert.AreEqual(expectedRes, actualRes);
        }
        [Test]
        public void CallThrowsExceptionWhenUserDoesNotExist()
        {
                        
            Assert.Throws<InvalidOperationException>(() =>
            {
                phone.Call("Pesho");
            });
        }
    }
}