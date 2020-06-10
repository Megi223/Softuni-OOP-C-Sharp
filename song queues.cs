using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp103
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> input = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
               // .Split(new[] { ',',' '}, StringSplitOptions.RemoveEmptyEntries)
                //.Split(',')
                //.Select(m=>m.Trim())
                //.Select(", ")
                .ToList();
            Queue<string> queueSongs = new Queue<string>();
            List<string> name = new List<string>(); 
            for (int i = 0; i < input.Count; i++)
            {
                queueSongs.Enqueue(input[i]);
            }
            while (queueSongs.Count > 0)
            {
                List<string> command = Console.ReadLine()
                .Split()
                 .ToList();
                string commandWord = command[0];

                if (commandWord == "Play")
                {
                    queueSongs.Dequeue();
                }
                else if (commandWord == "Add")
                {
                    for (int i = 1; i < command.Count; i++)
                    {
                        name.Add(command[i]);
                    }
                    string joined = string.Join(" ", name);
                    //string commandSec = command[1];
                    if (queueSongs.Contains(joined))
                    {
                        Console.WriteLine($"{joined} is already contained!");
                    }
                    else
                    {
                        queueSongs.Enqueue(joined);
                    }
                    name.Clear();
                    joined = "";
                }
                else if (commandWord == "Show")
                {
                    string joined = string.Join(", ", queueSongs);
                    Console.WriteLine(joined);
                }
            }
            if (queueSongs.Count == 0)
            {
                Console.WriteLine("No more songs!");
                return;
            }

        }
    }
}
