using System;
using System.Collections.Generic;
using System.Linq;

namespace P07MilitaryElite
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            //var leu = new LieutenantGeneral("hdhs","hdhs","hsh");

            ////cannot happen because of level of protecton leu.ListOfPrivates.Clear();
            //var priv = new Private("hdhs", "hdhs", "hsh");
            ////everything is alright with the private
            //var eng = new Engineer("hdhs", "hdhs", "hsh");
            ////everything is alright with the engineer
            //var com = new Commando("hdhs", "hdhs", "hsh");
            ////check lists in com=mission complete

            //var spy = new Spy("hdhs", "hdhs", "hsh",123);
            ////everything is alright with the spy

            string command;
            List<Private> privates = new List<Private>();
            while ((command=Console.ReadLine())!="End")
            {
                string[] commandToArr = command.Split().ToArray();
                string cmdType = commandToArr[0];

                if (cmdType == "Private")
                {
                    string id = commandToArr[1];
                    string firstName = commandToArr[2];
                    string lastName = commandToArr[3];
                    decimal salary = decimal.Parse(commandToArr[4]);
                    Private privatePerson = new Private(id, firstName, lastName, salary);
                    privates.Add(privatePerson);
                    Console.WriteLine(privatePerson.ToString());
                }
                else if(cmdType== "LieutenantGeneral")
                {
                    string id = commandToArr[1];
                    string firstName = commandToArr[2];
                    string lastName = commandToArr[3];
                    decimal salary = decimal.Parse(commandToArr[4]);
                    LieutenantGeneral gen = new LieutenantGeneral(id, firstName, lastName, salary);
                    for (int i = 5; i < commandToArr.Length; i++)
                    {
                        string privatesId = commandToArr[i];
                        Private toBeWritten = privates.FirstOrDefault(x => x.Id == privatesId);
                        gen.ListOfPrivates.Add(toBeWritten);
                        
                    }
                    Console.WriteLine(gen.ToString());
                }
                else if(cmdType== "Engineer")
                {
                    string id = commandToArr[1];
                    string firstName = commandToArr[2];
                    string lastName = commandToArr[3];
                    decimal salary = decimal.Parse(commandToArr[4]);
                    string corps = commandToArr[5];
                    try
                    {
                        Engineer engineer = new Engineer(id, firstName, lastName, salary, corps);
                        for (int i = 6; i < commandToArr.Length; i += 2)
                        {
                            string partName = commandToArr[i];
                            int hoursWorked = int.Parse(commandToArr[i + 1]);
                            Repair repair = new Repair(partName, hoursWorked);
                            engineer.ListOfRepairs.Add(repair);
                        }
                        Console.WriteLine(engineer.ToString());
                    }
                    catch (Exception)
                    {

                        
                    }
                    

                }
                else if(cmdType== "Commando")
                {
                    string id = commandToArr[1];
                    string firstName = commandToArr[2];
                    string lastName = commandToArr[3];
                    decimal salary = decimal.Parse(commandToArr[4]);
                    string corps = commandToArr[5];
                    try
                    {
                        Commando commando = new Commando(id, firstName, lastName, salary, corps);
                        for (int i = 6; i < commandToArr.Length; i += 2)
                        {
                            string missionCodeName = commandToArr[i];
                            string state = commandToArr[i + 1];
                            try
                            {
                                Mission mission = new Mission(missionCodeName, state);
                                commando.ListOfMissions.Add(mission);
                            }
                            catch (Exception)
                            {


                            }

                        }
                        Console.WriteLine(commando.ToString());
                    }
                    catch (Exception)
                    {

                        
                    }
                    
                }
                else if(cmdType== "Spy")
                {
                    string id = commandToArr[1];
                    string firstName = commandToArr[2];
                    string lastName = commandToArr[3];
                    int codeNumber = int.Parse(commandToArr[4]);
                    Spy spy = new Spy(id, firstName, lastName, codeNumber);
                    Console.WriteLine(spy);
                }
            }



        }
    }
}
