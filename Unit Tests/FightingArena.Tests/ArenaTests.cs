using NUnit.Framework;
using FightingArena;

using System;

namespace Tests
{
    public class ArenaTests
    {
        
        private Arena arena;
        private Warrior firstWarrior = new Warrior("Pesho", 50, 100);
        private Warrior secondWarrior = new Warrior("Ivan", 40, 200);
        private Warrior thirdWarrior = new Warrior("Gosho", 40, 40);

        [SetUp]
        public void Setup()
        {
            
            arena = new Arena();
        }

        [Test]
        public void ArenaInstantiatedProperly()
        {
            
            int expectedCount = 0;
            int actualCount = arena.Warriors.Count;
            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void EnrollShouldWorkProperly()
        {
            arena.Enroll(firstWarrior);
            int expectedCount = 1;
            int actualCount = arena.Count;
            Assert.AreEqual(expectedCount, actualCount);
        }
        [Test]
        public void EnrollShouldThrowExceptionWhenAddingAlredyPresentWarrior()
        {
            arena.Enroll(firstWarrior);
            Assert.Throws<InvalidOperationException>(() =>
            {
                arena.Enroll(firstWarrior);
            }, "Warrior is already enrolled for the fights!");
        }

        [Test]
        [TestCase(null)]
        [TestCase("Ana")]
        public void FightShouldThrowExceptionWhenAttackerNameNotPresent(string attackerName)
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                arena.Fight(attackerName, "Pesho");
            }, $"There is no fighter with name {attackerName} enrolled for the fights!");
        }

        [Test]
        [TestCase(null)]
        [TestCase("Ana")]
        public void FightShouldThrowExceptionWhenDefenderNameNotPresent(string defenderName)
        {
            arena.Enroll(firstWarrior);

            Assert.Throws<InvalidOperationException>(() =>
            {
                arena.Fight("Pesho", defenderName);
            }, $"There is no fighter with name {defenderName} enrolled for the fights!");
        }

        [Test]
        
        public void FightShouldWorkProperly()
        {
            int expextedAHp = this.firstWarrior.HP - this.secondWarrior.Damage;
            int expectedDHp = this.secondWarrior.HP - this.firstWarrior.Damage;
            arena.Enroll(firstWarrior);
            arena.Enroll(secondWarrior);
            arena.Fight(firstWarrior.Name, secondWarrior.Name);
            int actualAHp = firstWarrior.HP;
            int actualDHp = secondWarrior.HP;
            Assert.AreEqual(expextedAHp, actualAHp);
            Assert.AreEqual(expectedDHp, actualDHp);

        }
        [Test]

        public void FightShouldWorkProperlyCaseTwo()
        {
            int expextedAHp = this.firstWarrior.HP - this.thirdWarrior.Damage;
            int expectedDHp = 0;
            arena.Enroll(firstWarrior);
            arena.Enroll(thirdWarrior);
            arena.Fight(firstWarrior.Name, thirdWarrior.Name);
            int actualAHp = firstWarrior.HP;
            int actualDHp = thirdWarrior.HP;
            Assert.AreEqual(expextedAHp, actualAHp);
            Assert.AreEqual(expectedDHp, actualDHp);

        }

    }
}
