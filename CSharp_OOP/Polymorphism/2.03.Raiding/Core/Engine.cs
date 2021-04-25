using System;
using System.Linq;
using System.Collections.Generic;

using _2._03.Raiding.Models;
using _2._03.Raiding.Factories;

namespace _2._03.Raiding.Core
{
    public class Engine : IEngine
    {
        private const string VictoryMessage = "Victory!";
        private const string DefeatMessage = "Defeat...";

        private readonly HeroFactory heroFactory;
        private ICollection<BaseHero> heroes;

        public Engine()
        {
            this.heroFactory = new HeroFactory();
            heroes = new List<BaseHero>();
        }

        public void Run()
        {
            //ICollection<BaseHero> heroes = new List<BaseHero>();

            int lines = int.Parse(Console.ReadLine());
            int counter = 0;

            while (lines != counter)
            {
                string name = Console.ReadLine();
                string type = Console.ReadLine();

                try
                {
                    BaseHero hero = this.ProcessHero(name, type);

                    heroes.Add(hero);
                    counter++;
                }
                catch (Exception ae)
                {
                    Console.WriteLine(ae.Message);
                }

            }

            double bossPower = double.Parse(Console.ReadLine());

            int heroesPower = heroes.Sum(p => p.Power);

            foreach (BaseHero hero in heroes)
            {
                Console.WriteLine(hero.CastAbility());
            }

            if (heroesPower >= bossPower)
            {
                Console.WriteLine(VictoryMessage);
            }
            else
            {
                Console.WriteLine(DefeatMessage);
            }
        }


        private BaseHero ProcessHero(string name, string type)
        {
            BaseHero currentHero = this.heroFactory.CreateHero(name, type);

            return currentHero;
        }
    }
}
