using ExtendedDatabase;
using NUnit.Framework;
using System;

namespace Tests
{
    public class ExtendedDatabaseTests
    {
        private ExtendedDatabase.ExtendedDatabase extendedDatabase;
        private Person[] peopleArr;
        private Person firstPerson = new Person(1, "Pesho");
        private Person secondPerson = new Person(2, "Ivan");


        [SetUp]
        public void Setup()
        {
            this.peopleArr = new Person[2] { firstPerson, secondPerson };
            this.extendedDatabase = new ExtendedDatabase.ExtendedDatabase(this.peopleArr);
        }

        [Test]
        public void ConstructorShouldThrowExceptionIfMoreThan16People()
        {
            this.peopleArr = new Person[17];
            Assert.Throws<ArgumentException>(() =>
            {
                this.extendedDatabase = new ExtendedDatabase.ExtendedDatabase(this.peopleArr);
            });
        }

        [Test]
       
        public void ConstructorShouldWorkProperly()
        {
            

            int expectedCount = 2;
            int actualCount = this.extendedDatabase.Count;

            Assert.AreEqual(expectedCount, actualCount);
        }

       
        [Test]
        public void AddShouldThrowEWhenAddingPersonWithTheSameUserName()
        {
            Person person = new Person(3, "Pesho");
            Assert.Throws<InvalidOperationException>(() =>
            {
                this.extendedDatabase.Add(person);
            });

        }
        [Test]
        public void AddShouldThrowEWhenAddingPersonWithTheSameId()
        {
            Person person = new Person(1, "Gosho");
            Assert.Throws<InvalidOperationException>(() =>
            {
                this.extendedDatabase.Add(person);
            });

        }

        [Test]
        public void AddShouldWorkProperly()
        {
            Person person = new Person(3, "Gosho");
            this.extendedDatabase.Add(person);

            int expectedCount = 3;
            int actualCount = this.extendedDatabase.Count;

            Assert.AreEqual(expectedCount, actualCount);

        }

        [Test]
        public void AddShouldThrowEWhenAdding17Person()
        {

            Person[] people = new Person[16];
            for (int i = 0; i < people.Length; i++)
            {
                people[i] = new Person(i, "Ivan" + i);
            }
            this.extendedDatabase = new ExtendedDatabase.ExtendedDatabase(people);

            Assert.Throws<InvalidOperationException>
                (() => this.extendedDatabase.Add(new Person(200, "Ivan" + 200)));

        }

        [Test]
       
        public void RemoveShouldThrowExceptionWhenEmpty()
        {
            this.peopleArr = new Person[0];
            this.extendedDatabase = new ExtendedDatabase.ExtendedDatabase(this.peopleArr);
            Assert.Throws<InvalidOperationException>(() =>
            {
                this.extendedDatabase.Remove();
            });

        }
        [Test]
        public void RemoveShouldWorkProperly()
        {
            this.extendedDatabase.Remove();

            int expectedCount = 1;
            int actualCount = this.extendedDatabase.Count;

            Assert.AreEqual(expectedCount, actualCount);
        }

        //[Test]
        //public void RemovedPersonShouldBeNull()
        //{
        //    this.extendedDatabase.Remove();
        //    int expectedPeopleArrCount = 1;
        //    int actualCount = this.peopleArr.Length;
        //    Assert.AreEqual(expectedPeopleArrCount, actualCount);


        //}

        [Test]
        public void FindByNameShouldThrowExceptionWhenNameNull()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {

                 this.extendedDatabase.FindByUsername(null);
            });
        }
        [Test]
        public void FindByNameShouldThrowExceptionWhenNameDoesNotExist()
        {

            Assert.Throws<InvalidOperationException>(() =>
            {

                this.extendedDatabase.FindByUsername("Maria");
            });
        }
        [Test]
        public void FindByNameShouldWorkProperly()
        {

            Person actualPerson =this.extendedDatabase.FindByUsername("Pesho");
            Assert.AreEqual(firstPerson, actualPerson);
        }

        [Test]
        public void FindByIdShouldThrowExceptionWhenIdBelowZero()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {

                this.extendedDatabase.FindById(-1);
            });
        }
        [Test]
        public void FindByIdShouldThrowExceptionWhenIdDoesNotExist()
        {

            Assert.Throws<InvalidOperationException>(() =>
            {

                this.extendedDatabase.FindById(5);
            });
        }
        [Test]
        public void FindByIdShouldWorkProperly()
        {

            Person actualPerson = this.extendedDatabase.FindById(1);
            Assert.AreEqual(firstPerson, actualPerson);
        }

       



    }
}