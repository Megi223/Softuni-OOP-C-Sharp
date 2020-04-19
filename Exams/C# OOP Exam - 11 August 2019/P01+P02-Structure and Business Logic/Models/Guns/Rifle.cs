using System;
using System.Collections.Generic;
using System.Text;

namespace ViceCity.Models.Guns
{
    public class Rifle : Gun
    {
        private const int InitialBulletsPerBarrel = 50;
        private const int InitialTotalBullets = 500;
        private const int InitialRifleDamage = 5;
        public Rifle(string name) : base(name, 50, 500)
        {
        }

        public override int Fire()
        {
            if (this.BulletsPerBarrel - InitialRifleDamage <= 0 && this.TotalBullets > 0)
            {
                this.BulletsPerBarrel--;
                this.BulletsPerBarrel = InitialBulletsPerBarrel;
                this.TotalBullets -= InitialBulletsPerBarrel;
                return InitialRifleDamage;
            }

            if (this.CanFire == true)
            {
                this.BulletsPerBarrel--;
                return InitialRifleDamage;
            }

            return 0;
        }
    }
}
