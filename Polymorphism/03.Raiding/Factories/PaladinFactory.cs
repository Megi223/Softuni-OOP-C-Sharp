
using P03Raiding.Models;

namespace P03Raiding.Factories
{
    public class PaladinFactory : Factory
    {
        private const int POWER = 100;
        private string name;
        private int power;
        public PaladinFactory(string name)
        {
            this.name = name;
            this.power = POWER;
        }

        public override BaseHero CreateHero(string name)
        {
            return new Paladin(name);
        }
    }
}
