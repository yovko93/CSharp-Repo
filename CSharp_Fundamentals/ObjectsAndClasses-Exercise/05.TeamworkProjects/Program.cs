using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _05.TeamworkProjects
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Team> teams = new List<Team>();
            int countOfTeams = int.Parse(Console.ReadLine());

            for (int i = 0; i < countOfTeams; i++)
            {
                string[] info = Console.ReadLine().Split('-').ToArray();
                string user = info[0];
                string teamName = info[1];

                if (teams.Any(x => x.TeamName == teamName))
                {
                    Console.WriteLine($"Team {teamName} was already created!");
                    continue;
                }
                if (teams.Any(x => x.Creator == user))
                {
                    Console.WriteLine($"{user} cannot create another team!");
                    continue;
                }

                Team team = new Team(user, teamName);
                teams.Add(team);
                Console.WriteLine($"Team {teamName} has been created by {user}!");

            }

            string command = string.Empty;
            while ((command = Console.ReadLine()) != "end of assignment")
            {
                string[] info = command.Split("->").ToArray();
                string user = info[0];
                string teamName = info[1];

                if (!teams.Any(x => x.TeamName == teamName))
                {
                    Console.WriteLine($"Team {teamName} does not exist!");
                    continue;
                }
                if (teams.Any(x => x.members.Contains(user)) || teams.Any(x => x.Creator == user && x.TeamName == teamName))
                {
                    Console.WriteLine($"Member {user} cannot join team {teamName}!");
                    continue;
                }

                int index = teams.FindIndex(x => x.TeamName == teamName);
                teams[index].members.Add(user);

            }

            var teamsToBeDisband = teams
                .Where(x => x.members.Count == 0)
                .OrderBy(x => x.TeamName)
                .ToList();

            var validTeams = teams
                .Where(x => x.members.Count > 0)
                .OrderByDescending(x => x.members.Count)
                .ThenBy(x => x.TeamName)
                .ToList();

            foreach (var team in validTeams)
            {
                Console.WriteLine($"{team.TeamName}");
                Console.WriteLine($"- {team.Creator}");
                foreach (var member in team.members.OrderBy(x => x))
                {
                    Console.WriteLine($"-- {member}");
                }
            }

            Console.WriteLine("Teams to disband:");
            foreach (var team in teamsToBeDisband)
            {
                Console.WriteLine(team.TeamName);
            }
        }

        public class Team
        {
            public string Creator { get; set; }

            public string TeamName { get; set; }

            public List<string> members;

            public Team(string creator, string teamName)
            {
                this.Creator = creator;
                this.TeamName = teamName;
                members = new List<string>();
            }

            // не работи
            //public override string ToString()
            //{
            //    StringBuilder sb = new StringBuilder();
            //    sb.AppendLine($"{TeamName}");
            //    sb.AppendLine($"- {Creator}");

            //    foreach (var member in members)
            //    {
            //        sb.AppendLine($"-- {member}");
            //    }

            //    return sb.ToString().TrimEnd();
            //}
        }
    }
}
