using System;

using P03Raiding.IO.Contracts;

namespace P03Raiding.IO
{
    public class ConsoleReader : IReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
