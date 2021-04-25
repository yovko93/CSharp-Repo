using System;

using _2._03.Raiding.Models;

namespace _2._03.Raiding.Factories
{
    public class HeroFactory
    {

        public HeroFactory()
        {
        }

        public BaseHero CreateHero(string name, string type)
        {
            BaseHero hero;

            if (type == "Paladin")
            {
                hero = new Paladin(name);
            }
            else if (type == "Druid")
            {
                hero = new Druid(name);
            }
            else if (type == "Rogue")
            {
                hero = new Rogue(name);
            }
            else if (type == "Warrior")
            {
                hero = new Warrior(name);
            }
            else
            {
                throw new ArgumentException("Invalid hero!");
            }

            return hero;
        }
    }
}
