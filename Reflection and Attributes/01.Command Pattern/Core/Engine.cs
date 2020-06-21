using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommandPattern.Core.Contracts;
using CommandPattern.Models;

namespace CommandPattern.Core
{
    public class Engine : IEngine
    {
        private readonly ICommandInterpreter commandInterpreter;
        public Engine(ICommandInterpreter interpreter)
        {
            this.commandInterpreter = interpreter;
        }
        public void Run()
        {

            string input;
            while ((input=Console.ReadLine())!="Exit")
            {
                
                string result = commandInterpreter.Read(input);
                Console.WriteLine(result);
               
            }
            
        }
    }
}
