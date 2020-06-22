using System;
using System.Linq;
using System.Reflection;
using CommandPattern.Core.Contracts;

namespace CommandPattern.Models
{
    public class CommandInterpreter : ICommandInterpreter
    {
        public string Read(string args)
        {
            string[] argsSplit = args.Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();
            string commandName = (argsSplit[0]+"Command").ToLower();
            string[] commandArgs = argsSplit.Skip(1).ToArray();
            
            Type cmdType = Assembly.GetCallingAssembly().GetTypes().FirstOrDefault(n=>n.Name.ToLower()==commandName);

            if (cmdType == null)
            {
                throw new ArgumentException("Invalid command type!");
            }

            ICommand instanceType = Activator.CreateInstance(cmdType) as ICommand;
            if (instanceType == null)
            {
                throw new ArgumentException("Invalid command type!");
            }
            string result = instanceType.Execute(commandArgs);
            return result;
        }
    }
}
