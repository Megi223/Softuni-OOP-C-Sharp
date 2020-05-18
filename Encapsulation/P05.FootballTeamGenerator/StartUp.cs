using System;
using System.Collections.Generic;
using System.Linq;
using P05FootballTeamGenerator.Models;
using P05FootballTeamGenerator.Common;
namespace P05FootballTeamGenerator
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string command ;
            List<Team> teams = new List<Team>();

            while ((command = Console.ReadLine())!= "END")
            {
                try
                {
                    string[] commandToArr = command.Split(';').ToArray();

                    string cmdType = commandToArr[0];
                    if (cmdType == "Team")
                    {
                        string teamName = commandToArr[1];
                        Team team = new Team(teamName);
                        teams.Add(team);

                    }
                    else if (cmdType == "Add")
                    {
                        string teamName = commandToArr[1];
                        string playerName = commandToArr[2];
                        int endurance = int.Parse(commandToArr[3]);
                        int sprint = int.Parse(commandToArr[4]);
                        int dribble = int.Parse(commandToArr[5]);
                        int passing = int.Parse(commandToArr[6]);
                        int shooting = int.Parse(commandToArr[7]);

                        if (!teams.Any(p => p.Name == teamName))
                        {
                            throw new ArgumentException(String.Format(GlobalConstants.MissingTeamExceptionMessage, teamName));
                        }
                        Stats stats = new Stats(endurance, sprint, dribble, passing, shooting);
                        Player player = new Player(playerName, stats);
                        Team currentTeam = teams.First(t => t.Name == teamName);
                        currentTeam.AddPlayer(player);

                    }
                    else if (cmdType == "Remove")
                    {
                        string teamName = commandToArr[1];
                        string playerName = commandToArr[2];

                        if (!teams.Any(p => p.Name == teamName))
                        {
                            throw new ArgumentException(String.Format(GlobalConstants.MissingTeamExceptionMessage, teamName));
                        }

                        Team currentTeam = teams.First(t => t.Name == teamName);
                        currentTeam.RemovePlayer(playerName);

                    }
                    else if (cmdType == "Rating")
                    {
                        string teamName = commandToArr[1];
                        if (!teams.Any(p => p.Name == teamName))
                        {
                            throw new ArgumentException(String.Format(GlobalConstants.MissingTeamExceptionMessage, teamName));
                        }
                        Team currentTeam = teams.First(t => t.Name == teamName);
                        Console.WriteLine(currentTeam);


                    }


                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    
                }
                


                
            }
        }

        
    }
}
