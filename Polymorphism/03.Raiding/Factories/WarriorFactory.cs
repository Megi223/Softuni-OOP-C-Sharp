
using P03Raiding.Models;

namespace P03Raiding.Factories
{
    public class WarriorFactory : Factory
    {
        private const int POWER = 100;
        private string name;
        private int power;
        public WarriorFactory(string name)
        {
            this.name = name;
            this.power = POWER;
        }

        public override BaseHero CreateHero(string name)
        {
            return new Warrior(name);
        }
    }
}
