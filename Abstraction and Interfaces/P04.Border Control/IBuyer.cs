using System;
using System.Collections.Generic;
using System.Text;

namespace P04P05P06BorderControl
{
    public interface IBuyer
    {
        string Name { get; }
        int Food { get; }
        int BuyFood();
    }
}
