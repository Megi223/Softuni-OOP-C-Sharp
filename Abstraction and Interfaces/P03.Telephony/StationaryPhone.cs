using System;
using System.Collections.Generic;
using System.Text;

namespace P03Telephony
{
    public class StationaryPhone : ICallable
    {
        public StationaryPhone()
        {

        }
        public string Call()
        {
            return "Dialing... {0}";
        }
    }
}
