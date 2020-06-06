
using P03Raiding.Models;

namespace P03Raiding.Factories
{
    class DruidFactory : Factory
    {
        private const int POWER= 80;
        private string name;
        private int power;

        public DruidFactory(string name)
        {
            this.name = name;
            this.power = POWER;
        }
        public override BaseHero CreateHero(string name)
        {
            return new Druid(name);
        }
    }
}
