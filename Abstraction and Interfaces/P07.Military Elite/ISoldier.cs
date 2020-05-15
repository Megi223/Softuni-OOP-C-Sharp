using System;
using System.Collections.Generic;
using System.Text;

namespace P07MilitaryElite
{
    public interface ISoldier
    {
        string Id { get; }
        string FirstName { get; }
        string LastName { get; }
    }
}
