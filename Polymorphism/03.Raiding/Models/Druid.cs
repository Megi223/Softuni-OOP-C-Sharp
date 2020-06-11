

namespace P03Raiding.Models
{
    public class Druid : BaseHero
    {
        public Druid(string name) : base(name)
        {
            this.Power = 80;
        }

        public override string CastAbility()
        {
            return $"Druid - {this.Name} healed for {this.Power}";
        }
    }
}
