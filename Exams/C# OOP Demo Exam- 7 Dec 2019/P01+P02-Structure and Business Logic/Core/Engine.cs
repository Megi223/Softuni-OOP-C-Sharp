using MXGP.Core.Contracts;
using MXGP.IO;
using MXGP.IO.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace MXGP.Core
{
    public class Engine : IEngine
    {
        private ChampionshipController championshipController;
        private IWriter writer;
        private IReader reader;
        public Engine()
        {
            this.championshipController = new ChampionshipController();
            this.writer = new ConsoleWriter();
            this.reader = new ConsoleReader();
        }
        public void Run()
        {
            while (true)
            {
                string[] input = reader.ReadLine().Split();
                if (input[0] == "Exit")
                {
                    Environment.Exit(0);
                }
                //
                try
                {
                    //
                    string result = string.Empty;

                    if (input[0] == "CreateRider")
                    {
                        string name = input[1];
                       

                        result = championshipController.CreateRider(name);
                    }
                    else if (input[0] == "CreateMotorcycle")
                    {
                        string type = input[1];
                        string model = input[2];
                        int horsePower =int.Parse(input[3]);

                        result = championshipController.CreateMotorcycle(type,model, horsePower);
                    }
                    else if (input[0] == "AddMotorcycleToRider")
                    {
                        string riderName = input[1];
                        string motorName = input[2];

                        result = championshipController.AddMotorcycleToRider(riderName, motorName);
                    }
                    else if (input[0] == "AddRiderToRace")
                    {
                        string raceName = input[1];
                        string riderName = input[2];


                        result = championshipController.AddRiderToRace(raceName, riderName);
                    }
                    else if (input[0] == "CreateRace")
                    {
                        string name = input[1];
                        int laps = int.Parse(input[2]);


                        result = championshipController.CreateRace(name,laps);
                    }
                    else if (input[0] == "StartRace")
                    {
                        string name = input[1];

                        result = championshipController.StartRace(name);
                    }
                    

                    writer.WriteLine(result);
                    //
                }
                catch (Exception ex)
                {
                    writer.WriteLine(ex.Message);
                }
                //
            }
        }
    }
}
