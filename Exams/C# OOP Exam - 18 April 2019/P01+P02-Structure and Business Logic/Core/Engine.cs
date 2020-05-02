using PlayersAndMonsters.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlayersAndMonsters.Core
{
    public class Engine : IEngine
    {
        private IManagerController managerController;
        public Engine()
        {
            this.managerController = new ManagerController();
        }
        public void Run()
        {
            while (true)
            {
                var input = Console.ReadLine().Split();
                if (input[0] == "Exit")
                {
                    Environment.Exit(0);
                }
                try
                {
                    if (input[0] == "AddPlayer")
                    {
                        string type = input[1];
                        string name = input[2];
                        Console.WriteLine(managerController.AddPlayer(type,name));
                    }
                    else if (input[0] == "AddCard")
                    {
                        string type = input[1];
                        string name = input[2];
                        Console.WriteLine(managerController.AddCard(type, name));
                    }
                    else if (input[0] == "AddPlayerCard")
                    {
                        string username = input[1];
                        string cardName = input[2];
                        Console.WriteLine(managerController.AddPlayerCard(username,cardName));
                    }
                    else if (input[0] == "Fight")
                    {
                        string attacker = input[1];
                        string enemy = input[2];
                        Console.WriteLine(managerController.Fight(attacker, enemy));
                    }
                    else if (input[0] == "Report")
                    {
                        
                        Console.WriteLine(managerController.Report());
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    //throw;
                }
            }
        }
    }
}
