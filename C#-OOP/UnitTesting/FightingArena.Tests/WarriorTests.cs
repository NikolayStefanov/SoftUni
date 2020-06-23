using NUnit.Framework;
using System;
using FightingArena;

namespace Tests
{
    public class WarriorTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        [TestCase(null, 15, 100)]
        [TestCase("Skelet", 0, 100)]
        [TestCase("Skelet", -4, 100)]
        [TestCase("Skelet", 15, -15)]
        [TestCase("", 14, 100)]
        public void IfConstrucorRecieveInvalidNameDamageOrHPItShouldThrowsArgumentException(string name, int damage, int hp)
        {
            Assert.Throws<ArgumentException>(() => new Warrior(name, damage, hp));
        }
        [Test]
        public void ConstructorShouldWokrNormallyWithValidParameters()
        {
            var warr = new Warrior("Nikolay", 15, 100);
            Assert.AreEqual("Nikolay", warr.Name);
            Assert.AreEqual(15, warr.Damage);
            Assert.AreEqual(100, warr.HP);
        }

        [Test]
        [TestCase("Nikolay", 50, 100, "SecondWarr", 18, 49)]
        [TestCase("Nikolay", 12, 100, "SecondWarr", 18, 30)]
        [TestCase("Nikolay", 12, 100, "SecondWarr", 18, 20)]
        [TestCase("Nikolay", 12, 30, "SecondWarr", 20, 55)]
        [TestCase("Nikolay", 12, 11, "SecondWarr", 20, 55)]

        public void WarriorMethodAttackShouldThrowInvalidOperationExceptionIfYouTryToAttackStrongerEnemy
            (string firstWarrName, int firstWarrDamage, int firstWarrHP,
            string secondWarrName, int secondWarrDamage, int secondWarrHp)
        {
            var parameterWarr = new Warrior(firstWarrName, firstWarrDamage, firstWarrHP);
            var callerWarr = new Warrior(secondWarrName, secondWarrDamage, secondWarrHp);
            Assert.Throws<InvalidOperationException>(() => callerWarr.Attack(parameterWarr));
        }

        [Test]
        public void WarriorMethodAttackShouldWorkCorrectly()
        {
            var stronger = new Warrior("Nikolay", 20, 100);
            var weaker = new Warrior("Peshkata", 20, 100);
            var expectedHp = 80;
            weaker.Attack(stronger);
            Assert.AreEqual(expectedHp, weaker.HP);
        }
        [Test]
        public void WarriorMethodAttackShouldWorkCorrectlyIfDamageIsMoreThanHealth()
        {
            var stronger = new Warrior("Nikolay", 50, 100);
            var weaker = new Warrior("Peshkata", 20, 83);
            stronger.Attack(weaker);
            Assert.AreEqual(80, stronger.HP);
            Assert.AreEqual(33, weaker.HP);
            stronger.Attack(weaker);
            Assert.AreEqual(60, stronger.HP);
            Assert.AreEqual(0, weaker.HP);
        }
    }
}