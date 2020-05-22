using System;
using System.Linq;
using System.Collections.Generic;

using Logger.Core;
using Logger.Factories;
using Logger.Core.Contracts;
using Logger.Models.Contracts;

namespace Logger
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int appendersCount = int.Parse(Console.ReadLine());
            ICollection<IAppender> appenders = new List<IAppender>();

            ParseAppendersInput(appendersCount, appenders);

            ILogger logger = new Logger.Models.Logger(appenders);

            IEngine engine = new Engine(logger);
            engine.Run();

        }

        private static void ParseAppendersInput(int appendersCount, ICollection<IAppender> appenders)
        {
            AppenderFactory appenderFactory = new AppenderFactory();
            for (int i = 0; i < appendersCount; i++)
            {
                string[] appenderArgs = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string appenderType = appenderArgs[0];
                string layoutType = appenderArgs[1];
                string level = "INFO";

                if (appenderArgs.Length == 3)
                {
                    level = appenderArgs[2];
                }
                try
                {
                    IAppender appender = appenderFactory.ProduceAppender(appenderType, layoutType, level);
                    appenders.Add(appender);
                }
                catch (ArgumentException ae)
                {

                    Console.WriteLine(ae.Message);
                }
            }
        }
    }
}
