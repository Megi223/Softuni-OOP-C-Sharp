using System;
using System.Linq;
using System.Collections.Generic;

using P03Raiding.Models;
using P03Raiding.Factories;
using P03Raiding.IO.Contracts;
using P03Raiding.Core.Contracts;

namespace P03Raiding.Core
{
    public class Engine : IEngine
    {
        private List<BaseHero> heroes;
        private Factory factory;
        private IReader reader;
        private IWriter writer;

        public Engine(IReader reader,IWriter writer)
        {
            this.heroes = new List<BaseHero>();
            this.factory = null;
            this.reader = reader;
            this.writer = writer;
        }
        
        public void Run()
        {
            int n = int.Parse(this.reader.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] heroNameArgs = this.reader.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string heroName = heroNameArgs[0];
                string[] heroTypeArgs = this.reader.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string heroType = heroTypeArgs[0].ToLower();

                if (heroType == "druid")
                {
                    factory = new DruidFactory(heroName);
                }
                else if (heroType == "paladin")
                {
                    factory = new PaladinFactory(heroName);
                }
                else if (heroType == "rogue")
                {
                    factory = new RogueFactory(heroName);
                }
                else if (heroType == "warrior")
                {
                    factory = new WarriorFactory(heroName);
                }
                else
                {
                    Console.WriteLine("Invalid hero!");
                    i--;

                }
                if (factory != null)
                {

                    BaseHero hero = factory.CreateHero(heroName);
                    heroes.Add(hero);
                    //possible mistake- printing of CastAbility should happen after reading all input
                    //Console.WriteLine(hero.CastAbility());
                }
                factory = null;

            }
            int bossPower = int.Parse(Console.ReadLine());
            int totalPower = heroes.Sum(p => p.Power);
            foreach (var item in heroes)
            {
                Console.WriteLine(item.CastAbility());
            }
            if (totalPower >= bossPower)
            {
                Console.WriteLine("Victory!");
            }
            else
            {
                Console.WriteLine("Defeat...");
            }

        }
    }
}
