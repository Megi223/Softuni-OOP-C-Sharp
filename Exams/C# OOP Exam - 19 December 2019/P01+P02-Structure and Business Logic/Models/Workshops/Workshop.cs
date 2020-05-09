﻿using SantaWorkshop.Models.Dwarfs.Contracts;
using SantaWorkshop.Models.Instruments.Contracts;
using SantaWorkshop.Models.Presents.Contracts;
using SantaWorkshop.Models.Workshops.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SantaWorkshop.Models.Workshops
{
    public class Workshop : IWorkshop
    {
        public Workshop()
        {
                
        }
        public void Craft(IPresent present, IDwarf dwarf)
        {
            while (dwarf.Energy>0 && dwarf.Instruments.Count!=0)
            {
                IInstrument currentInstrument = dwarf.Instruments.First(i=>!i.IsBroken());
                while (dwarf.Energy>0 && currentInstrument.IsBroken()==false && present.IsDone()==false)
                {
                    dwarf.Work();
                    present.GetCrafted();
                    currentInstrument.Use();
                    
                }
                if (currentInstrument.IsBroken())
                {
                    dwarf.Instruments.Remove(currentInstrument);
                }
                if (present.IsDone())
                {
                    break;
                }
            }
        }
    }
}
