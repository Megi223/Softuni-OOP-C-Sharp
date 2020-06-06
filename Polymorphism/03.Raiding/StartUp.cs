
using P03Raiding.Core;
using P03Raiding.Core.Contracts;
using P03Raiding.IO;
using P03Raiding.IO.Contracts;

namespace P03Raiding
{
    class StartUp
    {
        static void Main(string[] args)
        {
            IReader reader = new ConsoleReader();
            IWriter writer = new ConsoleWriter();

            IEngine engine = new Engine(reader,writer);
            engine.Run();
           
        }
    }
}
