
using P03Raiding.Models;

namespace P03Raiding.Factories
{
    public abstract class Factory
    {
        public abstract BaseHero CreateHero(string name);
    }
}
