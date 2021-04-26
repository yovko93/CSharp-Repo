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
        [TestCase("Pesho", 50, 100)]
        [TestCase("Gosho", 150, 100)]
        [TestCase("Ivan", 150, 0)]
        public void WarriorConstructorShouldSetAllDataCorrectly(
            string name,
            int damage,
            int hp)
        {
            //Arrange / Act
            Warrior warrior = new Warrior(
                name: name,
                damage: damage,
                hp: hp);

            //Assert
            Assert.AreEqual(warrior.Name, name);
            Assert.AreEqual(warrior.Damage, damage);
            Assert.AreEqual(warrior.HP, hp);
        }

        [Test]
        [TestCase(" ")]
        [TestCase("")]
        [TestCase(null)]
        public void WarriorConstructorShouldThrowExceptionIfNameIsNullOrWhiteSpace(string name)
        {
            Assert.Throws<ArgumentException>(() =>
            new Warrior(name, 100, 100));
        }

        [Test]
        [TestCase(0)]
        [TestCase(-20)]
        public void WarriorConstructorShouldThrowExceptionIfDamageIsZeroOrNegative(int damage)
        {
            Assert.Throws<ArgumentException>(() =>
            new Warrior("Gosho", damage, 100));
        }

        [Test]
        [TestCase(-20)]
        public void WarriorConstructorThrowsExceptionIfHpIsNegativ(int hp)
        {
            Assert.Throws<ArgumentException>(() => 
            new Warrior("Pesho", 100, hp));
        }

        [Test]
        [TestCase("Stoyan", 10, 10, "Ivan", 10, 10)]
        [TestCase("Stoyan", 10, 100, "Ivan", 10, 10)]
        [TestCase("Stoyan", 10, 50, "Ivan", 100, 50)]
        public void AttackShouldThrowExceptionIfHpIsBelowOrEqualToZero(string fighterName, int fighterDmg, int fighterHp,
            string defenderName, int defenderDmg, int defenderHp)
        {
            //Arrange
            Warrior fighter = new Warrior(fighterName, fighterDmg, fighterHp);
            Warrior defender = new Warrior(defenderName, defenderDmg, defenderHp);

            //Act / Assert
            Assert.Throws<InvalidOperationException>(() =>
            fighter.Attack(defender));
        }

        [Test]
        [TestCase("Stoyan", 10, 50, 40, "Ivan", 10, 50, 40)]
        [TestCase("Stoyan", 20, 100, 90, "Ivan", 10, 70, 50)]
        [TestCase("Stoyan", 50, 100, 90, "Ivan", 10, 40, 0)]
        public void WarriorAttackOperationShouldDecreaseHp(
            string fighterName, int fighterDmg, int fighterHp, int fighterHpLeft,
            string defenderName, int defenderDmg, int defenderHp, int defenderHpLeft)
        {
            //Arrange
            Warrior fighter = new Warrior(fighterName, fighterDmg, fighterHp);
            Warrior defender = new Warrior(defenderName, defenderDmg, defenderHp);

            //Act
            fighter.Attack(defender);

            //Assert
            var expectedFighterHp = fighterHpLeft;
            var expectedDefenderHp = defenderHpLeft;

            Assert.AreEqual(expectedFighterHp, fighter.HP);
            Assert.AreEqual(expectedDefenderHp, defender.HP);

        }
    }
}