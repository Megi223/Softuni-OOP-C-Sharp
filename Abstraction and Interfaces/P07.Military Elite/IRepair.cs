using System;
using System.Collections.Generic;
using System.Text;

namespace P07MilitaryElite
{
    public interface IRepair
    {
        string PartName { get; }
        int HoursWorked { get; }
    }
}
