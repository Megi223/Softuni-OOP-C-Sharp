
using P03Raiding.Models;

namespace P03Raiding.Factories
{
    public class RogueFactory : Factory
    {
        private const int POWER = 80;
        private string name;
        private int power;
        public RogueFactory(string name)
        {
            this.name = name;
            this.power = POWER;
                
        }
        public override BaseHero CreateHero(string name)
        {
            return new Rogue(name);
        }
    }
}
