using System;
using System.Linq;
using System.Collections.Generic;

using _2._05.FootballTeamGenerator.Common;
using _2._05.FootballTeamGenerator.Models;

namespace _2._05.FootballTeamGenerator.Core
{
    public class Engine
    {
        private readonly ICollection<Team> teams;

        public Engine()
        {
            this.teams = new List<Team>();
        }

        public void Run()
        {
            string command;
            while ((command = Console.ReadLine()) != "END")
            {
                string[] data = command
                    .Split(";")
                    .ToArray();

                try
                {
                    List<string> commandParams = data
                        .Skip(1)
                        .ToList();

                    switch (data[0])
                    {
                        case "Team":
                            string teamName = data[1];
                            this.CreateTeam(teamName);
                            break;

                        case "Add":
                            this.AddPlayerToTeam(commandParams);
                            break;

                        case "Remove":
                            this.RemovePlayerFromTeam(commandParams);
                            break;

                        case "Rating":
                            this.RateTeam(commandParams);
                            break;
                    }

                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
                catch(InvalidOperationException ioe)
                {
                    Console.WriteLine(ioe.Message);
                }

            }

        }

        private void CreateTeam(string teamName)
        {
            Team team = new Team(teamName);

            this.teams.Add(team);
        }

        private void AddPlayerToTeam(IList<string> data)
        {
            string teamName = data[0];
            string playerName = data[1];

            this.ValidateTeamExist(teamName);

            Stats stats = this.BuildStats(data.Skip(2).ToArray());

            Player player = new Player(playerName, stats);

            Team team = this.teams.First(t => t.Name == teamName);
            team.AddPlayer(player);
        }

        private void RemovePlayerFromTeam(IList<string> data)
        {
            string teamName = data[0];
            string playerName = data[1];

            Team team = this.teams.First(t => t.Name == teamName);

            team.RemovePlayer(playerName);
        }

        private void RateTeam(IList<string> data)
        {
            string teamName = data[0];

            this.ValidateTeamExist(teamName);

            Team team = this.teams.First(t => t.Name == teamName);

            Console.WriteLine(team);
        }

        private Stats BuildStats(string[] statsString)
        {
            int endurance = int.Parse(statsString[0]);
            int sprint = int.Parse(statsString[1]);
            int dribble = int.Parse(statsString[2]);
            int passing = int.Parse(statsString[3]);
            int shooting = int.Parse(statsString[4]);

            Stats stats = new Stats(endurance, sprint, dribble, passing, shooting);

            return stats;
        }

        private void ValidateTeamExist(string teamName)
        {
            if (!this.teams.Any(t=> t.Name == teamName))
            {
                throw new InvalidOperationException(string.Format(GlobalConstants.TEAM_NOT_EXIST_EXC_MSG, teamName));
            }
        }

      
    }
}
