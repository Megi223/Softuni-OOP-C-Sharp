
using NUnit.Framework;
using System;
using System.Linq;

namespace Tests
{
    public class DatabaseTests
    {
        private Database.Database database;
        
        private int[] arr;

        [SetUp]
        public void Setup()
        {
            arr = new int[] { 0, 1 };
            //this.database = new Database(this.arr);
             
        }

        [Test]
        //[TestCase(new int[] { 1,2,3})]
        public void ConstructorShouldWorkProperly()
        {
            //this.database = new Database.Database(this.arr);
            this.database = new Database.Database(this.arr);

            int expectedCount = arr.Length;
            int actualCount = this.database.Count;

            Assert.AreEqual(expectedCount, actualCount);
           
        }

        [Test]
        public void ConstructorShouldWorkWithZeroParameters()
        {
            this.database = new Database.Database(new int[0]);

            int expectedCount = 0;
            int actualCount = this.database.Count;

            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        [TestCase(new int[] {1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16 })]
        public void AddShouldThrowExceptionIfAddedMoreElements(int[] data)
        {
            this.database = new Database.Database(data);
            Assert.Throws<InvalidOperationException>
                (
                     () =>
                         {
                             this.database.Add(2);
                         }
                );
        }

        
        [Test]
        public void ConstructorShouldWorkExactlyWith16Numbers()
        {
            int[] bigArr = new int[17];

            Assert.Throws<InvalidOperationException>
                (() =>
                {
                    this.database = new Database.Database(bigArr);
                }

                );
        }

        [Test]
       
        public void AddShouldWorkProperly()
        {
            this.database = new Database.Database(this.arr);

            this.database.Add(2);
            int expectedCount = 3;
            int actualCount = this.database.Count;

            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void RemoveShouldWorkProperly()
        {
            this.database = new Database.Database(this.arr);
            this.database.Remove();

            int expectedCount = 1;
            int actualCount = database.Count;

            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void RemoveShouldThrowExceptionWhenRemovingFromEmptyArr()
        {
            this.database = new Database.Database(new int[0]);

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.database.Remove();
            });

        }

        [Test]
        public void FetchShouldWorkProperly()
        {
            this.database = new Database.Database(this.arr);
            int[] newArr = this.database.Fetch();
            CollectionAssert.AreEqual(this.arr, newArr);
        }
    }
}