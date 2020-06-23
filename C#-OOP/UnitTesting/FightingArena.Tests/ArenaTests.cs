using FightingArena;
using NUnit.Framework;
using System;

namespace Tests
{
    public class ArenaTests
    {
        Warrior firstWarr;
        Warrior secondWarr;
        Arena theArena;
        
        [SetUp]
        public void Setup()
        {
            firstWarr = new Warrior("Koko", 20, 100);
            secondWarr = new Warrior("Poly", 25, 75);
            theArena = new Arena();

        }

        [Test]
        public void ArenaMethodEnrollShouldReturnCorrectCount()
        {
            theArena.Enroll(firstWarr);
            theArena.Enroll(secondWarr);
            Assert.AreEqual(2, theArena.Warriors.Count);
            Assert.AreEqual(2, theArena.Count);
        }

        [Test]
        public void ArenaMethodEnrollShouldThrowInvalidOperationExceptionIfYouTryToEnrollWarriorWithAlreadyExistingName()
        {
            theArena.Enroll(firstWarr);
            theArena.Enroll(secondWarr);
            var thirdWarr = new Warrior("Poly", 200, 500);
            Assert.Throws<InvalidOperationException>(() => theArena.Enroll(thirdWarr));
        }

        [Test]
        [TestCase("InvalidName", "Koko")]
        [TestCase("Poly", "Django")]
        public void ArenaMethodFightShouldThrowInvalidOperationExceptionIfGivenWarriorNameDoesntExist(string attackerName, string defenderName)
        {
            theArena.Enroll(firstWarr);
            theArena.Enroll(secondWarr);
            Assert.Throws<InvalidOperationException>(() => theArena.Fight(attackerName, defenderName));
            Assert.Throws<InvalidOperationException>(() => theArena.Fight(attackerName, defenderName));
        }

        [Test]
        public void ArenaMethodFightShouldWorkCorrectly()
        {
            theArena.Enroll(firstWarr);
            theArena.Enroll(secondWarr);
            theArena.Fight("Koko", "Poly");
            Assert.AreEqual(75, firstWarr.HP);
            Assert.AreEqual(55, secondWarr.HP);
        }
    }
}
