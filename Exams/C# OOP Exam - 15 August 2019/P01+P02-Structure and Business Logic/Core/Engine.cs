using SpaceStation.Core.Contracts;
using SpaceStation.IO;
using SpaceStation.IO.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceStation.Core
{
    public class Engine : IEngine
    {
        private IWriter writer;
        private IReader reader;
        private IController controller;

        public Engine()
        {
            this.writer = new Writer();
            this.reader = new Reader();
            this.controller = new Controller();
        }
        public void Run()
        {
            while (true)
            {
                string result = string.Empty;
                var input = reader.ReadLine().Split();
                if (input[0] == "Exit")
                {
                    Environment.Exit(0);
                }
                try
                {
                    if (input[0] == "AddAstronaut")
                    {
                        string type = input[1];
                        string name = input[2];
                        result = controller.AddAstronaut(type, name);
                    }
                    else if (input[0] == "AddPlanet")
                    {
                        string name = input[1];
                        ICollection<string> collection = new List<string>();
                        for (int i = 2; i < input.Length; i++)
                        {
                            collection.Add(input[i]);
                        }
                        string[] arr = collection.ToArray();
                        result = controller.AddPlanet(name, arr);

                    }
                    else if (input[0] == "RetireAstronaut")
                    {
                        string name = input[1];
                        result = controller.RetireAstronaut(name);
                    }
                    else if (input[0] == "ExplorePlanet")
                    {
                        string name = input[1];
                        result = controller.ExplorePlanet(name);
                    }
                    else if(input[0] == "Report")
                    {
                        result = controller.Report();
                    }
                    this.writer.WriteLine(result);
                }
                catch (Exception ex)
                {
                    writer.WriteLine(ex.Message);
                }
            }
        }
    }
}
