using FightingArena;
using NUnit.Framework;
using System;

namespace Tests
{
    public class WarriorTests
    {
        Warrior warrior;
        [SetUp]
        public void Setup()
        {
            warrior = new Warrior("Pesho", 50, 100);
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase("      ")]

        public void NameShouldThrowExceptionWhenInvalid(string name)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Warrior warrior = new Warrior(name, 50, 100);
            }, "Name should not be empty or whitespace!");
        }

        [Test]
        [TestCase(0)]
        [TestCase(-1)]
        public void DamageShouldThrowExceptionWhenNegative(int damage)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Warrior warrior = new Warrior("Pesho", damage, 100);
            }, "Damage value should be positive!");
        }
        [Test]
        
        [TestCase(-1)]
        public void HPShouldThrowExceptionWhenNegative(int hp)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Warrior warrior = new Warrior("Pesho", 100, hp);
            }, "HP should not be negative!");
        }


        [Test]
        public void WarriorShouldInstantiateCorrectly()
        {
            Assert.AreEqual("Pesho", this.warrior.Name);
            Assert.AreEqual(50, this.warrior.Damage);
            Assert.AreEqual(100,this.warrior.HP);
        }
        [Test]
        [TestCase(20)]
        [TestCase(30)]
        public void AttackShouldThrowExceptionWhenAHpBelowMinIs(int hp)
        {
            Warrior attacker = new Warrior("some name", 50, hp);
            Warrior defender = new Warrior("def", 10, 40);
            Assert.Throws<InvalidOperationException>(() =>
            {
                attacker.Attack(defender);
            }, "Your HP is too low in order to attack other warriors!");
        }

        [Test]
        [TestCase(20)]
        [TestCase(30)]
        public void AttackShouldThrowExceptionWhenDHpBelowMinIs(int hp)
        {
            Warrior attacker = new Warrior("name", 10, 100);
            Warrior def = new Warrior("some", 10, hp);
            Assert.Throws<InvalidOperationException>(() =>
            {
                attacker.Attack(def);
            }, "Enemy HP must be greater than 30 in order to attack him!");
        }

        [Test]
        public void AttackShouldThrowExceptionWhenAttackingTooStrongWarrior()
        {
            Warrior defender = new Warrior("name", 200, 60);
            Assert.Throws<InvalidOperationException>(() =>
            {
                warrior.Attack(defender);
            }, "You are trying to attack too strong enemy");

        }

        [Test]
        public void AHpDecreasesByDDamage()
        {
            Warrior defender = new Warrior("Ivan", 40, 100);
            warrior.Attack(defender);
            int expectedAHp = 60;
            int actualAHp = this.warrior.HP;

            int expectedDHealth = 50;
            int actualDHp = defender.HP;
            Assert.AreEqual(expectedAHp, actualAHp);
            Assert.AreEqual(expectedDHealth, actualDHp);


        }
        [Test]
        public void WarriorHpIsSetCorrectlyWhenDHpIsGreaterThanADamage()
        {
            Warrior defender = new Warrior("Ivan", 40, 40);
            warrior.Attack(defender);
            int expectedDefHp = 0;
            int actualDefHp = defender.HP;
            int expectedAHp = 60;
            int actualAHp = this.warrior.HP;
            Assert.AreEqual(expectedAHp, actualAHp);

            Assert.AreEqual(expectedDefHp, actualDefHp);
        }

        [Test]
        [TestCase(40)]
        [TestCase(50)]
        public void WarriorHpIsSetCorrectlyWhenDHpIsNOTGreaterThanADamage(int dHP)
        {
            Warrior defender = new Warrior("Ivan", 40, dHP);
            warrior.Attack(defender);
            int expectedDefHp = 0;
            int actualDefHp = defender.HP;
            Assert.AreEqual(expectedDefHp, actualDefHp);


        }


        
    }
}