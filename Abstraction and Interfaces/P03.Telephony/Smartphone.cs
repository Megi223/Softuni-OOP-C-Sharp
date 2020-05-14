using System;
using System.Collections.Generic;
using System.Text;

namespace P03Telephony
{
    public class Smartphone : ICallable, IBrowsable

    {
        public Smartphone()
        {

        }
        public string Browse()
        {
            return "Browsing: {0}!";
        }

        public string Call()
        {
            return "Calling... {0}";
        }
    }
}
