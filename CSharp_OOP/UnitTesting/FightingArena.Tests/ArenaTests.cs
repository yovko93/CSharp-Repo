using NUnit.Framework;
using System;
using System.Linq;
using FightingArena;

namespace Tests
{
    public class ArenaTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ConstructorShouldInitializeDependantValues()
        {
            Arena arena = new Arena();

            Assert.IsNotNull(arena.Warriors);
        }

        [Test]
        public void EnrollShouldThrowExceptionIfWarriorExist()
        {
            Arena arena = new Arena();

            Warrior warrior = new Warrior("Stoyan", 100, 100);
            arena.Enroll(warrior);

            Assert.Throws<InvalidOperationException>(() =>
             arena.Enroll(warrior));
        }

        [Test]
        public void EnrollShouldAddWarriorToCollection()
        {
            Arena arena = new Arena();

            Warrior warrior1 = new Warrior("Stoyan", 100, 100);
            Warrior warrior2 = new Warrior("Kiro", 100, 100);
            arena.Enroll(warrior1);
            arena.Enroll(warrior2);

            var expectedCount = 2;
            var stoyan = arena.Warriors.Any(x => x.Name == "Stoyan");
            var kiro = arena.Warriors.Any(x => x.Name == "Kiro");

            Assert.AreEqual(expectedCount, arena.Count);
            Assert.IsTrue(stoyan);
            Assert.IsTrue(kiro);
        }

        [Test]
        [TestCase("Gosho", "Stoyan")]
        [TestCase("Gosho", null)]
        public void FightShouldThrowExceptionIfWarriorDoesntExist(
            string fighter, string defender)
        {
            Arena arena = new Arena();

            Assert.Throws<InvalidOperationException>(() =>
           arena.Fight(fighter, defender));

            Warrior warrior = new Warrior(fighter, 100, 100);
            arena.Enroll(warrior);

            Assert.Throws<InvalidOperationException>(() =>
            arena.Fight(fighter, defender));
        }

        [Test]
        public void FightShouldWorkAsExpected()
        {
            Arena arena = new Arena();

            Warrior fighter = new Warrior("Stoyan", 10, 100);
            Warrior defender = new Warrior("Kiro", 10, 100);

            arena.Enroll(fighter);
            arena.Enroll(defender);

            arena.Fight("Stoyan", "Kiro");

            var kiroHp = arena.Warriors.FirstOrDefault(n => n.Name == "Kiro").HP;

            var stoyanHp = arena.Warriors.FirstOrDefault(n => n.Name == "Stoyan").HP;

            Assert.AreEqual(kiroHp, 90);
            Assert.AreEqual(stoyanHp, 90);
        }
    }
}
