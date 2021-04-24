using FakeAxeAndDummy.Contracts;

public class StartUp
{
    static void Main(string[] args)
    {
        IWeapon weapon = new Axe(10, 10);
        ITarget target = new Dummy(10, 20);
        Hero hero = new Hero("Pesho", weapon);

        hero.Attack(target);
    }
}
