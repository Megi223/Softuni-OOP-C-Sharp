using CounterStrike.Models.Maps.Contracts;
using CounterStrike.Models.Players;
using CounterStrike.Models.Players.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CounterStrike.Models.Maps
{
    public class Map : IMap
    {
        public string Start(ICollection<IPlayer> players)
        {
            List<IPlayer> terrorists = new List<IPlayer>();
            List<IPlayer> counterTerrorists = new List<IPlayer>();
            foreach (var currentPlayer in players)
            {
                if (currentPlayer.GetType().Name == "Terrorist")
                {
                    terrorists.Add(currentPlayer);
                }
                else if (currentPlayer.GetType().Name == "CounterTerrorist")
                {
                    counterTerrorists.Add(currentPlayer);
                }
            }
            while (terrorists.Any(t => t.IsAlive) && counterTerrorists.Any(c => c.IsAlive))
            {

                foreach (var curTer in terrorists)
                {
                    if (curTer.IsAlive && curTer.Gun!=null && curTer.Gun.BulletsCount>0)
                    
                    {
                        int damage = curTer.Gun.Fire();
                        foreach (var counterTer in counterTerrorists)
                        {
                            if (counterTer.IsAlive)
                            {
                                counterTer.TakeDamage(damage);
                                
                            }
                        }
                    }

                }
                

                foreach (var curCounterTer in counterTerrorists)
                {
                    if (curCounterTer.IsAlive && curCounterTer.Gun!=null && curCounterTer.Gun.BulletsCount>0)
                    
                    {
                        int damage = curCounterTer.Gun.Fire();
                        foreach (var curTer in terrorists)
                        {
                            if (curTer.IsAlive)
                            {
                                curTer.TakeDamage(damage);
                            }
                        }
                    }

                }
                if (counterTerrorists.All(p => p.IsAlive == false))
                {
                    break;
                }
                if (terrorists.All(p => p.IsAlive == false))
                {
                    break;
                }

            }
            if (terrorists.All(t => !t.IsAlive))
            {
                return "Counter Terrorist wins!";
            }
            return "Terrorist wins!";
        }



    }
}
