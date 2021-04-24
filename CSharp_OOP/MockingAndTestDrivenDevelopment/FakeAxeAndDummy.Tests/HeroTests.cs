using NUnit.Framework;

//using FakeAxeAndDummy.Contracts;
//using FakeAxeAndDummy.Tests.Fakes;
using Moq;

[TestFixture]
public class HeroTests
{
    [Test]
    public void GivenHero_WhenAttackedTargetDies_ThenHeroReceivesExp()
    {

        //IWeapon weapon = new Axe(10, 10);
        //ITarget target = new Dummy(10, 20);

        //// Fakes
        //ITarget fakeTarget = new ITargetFake();
        //IWeapon fakeWeapon = new IWeaponFake();

        // Mocking
        Mock<IWeapon> weapon = new Mock<IWeapon>();
        Mock<ITarget> target = new Mock<ITarget>();

        target.Setup(t => t.GiveExperience()).Returns(20);
        target.Setup(t => t.IsDead()).Returns(true);
        weapon.Setup(x => x.AttackPoints).Returns(10);
        weapon.Setup(x => x.DurabilityPoints).Returns(10);

        Hero hero = new Hero("Pesho", weapon.Object);

        hero.Attack(target.Object);

        Assert.AreEqual(20, hero.Experience);
    }
}