using System;
using System.Linq;

namespace P09ExplicitInterfaces
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string command;
            while ((command=Console.ReadLine())!="End")
            {
                string[] comArgs = command.Split().ToArray();
                string name = comArgs[0];
                string country = comArgs[1];
                int age = int.Parse(comArgs[2]);
                IPerson citizenPerson = new Citizen(name, country, age);
                IResident citizenResident = new Citizen(name, country, age);
                Console.WriteLine(String.Format(citizenPerson.GetName(),name));
                Console.WriteLine(String.Format(citizenResident.GetName(), name));
            }
        }
    }
}
