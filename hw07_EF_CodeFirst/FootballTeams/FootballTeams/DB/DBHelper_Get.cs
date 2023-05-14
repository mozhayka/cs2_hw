using System.Data.Entity;

namespace FootballTeams.DB
{
    internal partial class DBHelper
    {
        public Player GetPlayer(string firstName)
        {
            return db.Players.First(p => p.FirstName == firstName);
        }

        public Team GetTeam(string teamName)
        {
            return db.Teams.Include(x => x.Stats).First(p => p.Name == teamName);
        }

        public List<Player> GetTeamPlayers(Team team)
        {
            return team.Players.ToList();
        }

        public void PrintAllTeams()
        {
            foreach (Team t in db.Teams.Include(x => x.Players))
            {
                Console.WriteLine("Команда: {0}", t.Name);
                foreach (Player pl in t.Players)
                {
                    Console.WriteLine("{0} - {1}", pl.FirstName, pl.SecondName);
                }
                Console.WriteLine();
            }
        }

        public void PrintTeamStats(Team team)
        {
            Console.WriteLine($"{team.Name}: ");
            Console.WriteLine($"stadiums: {team.Stats.NumberOfStadiums}");
            Console.WriteLine($"players: {team.Stats.NumberOfPlayers}");
            Console.WriteLine($"avg goals: {team.Stats.AvgGoals}");
        }
    }
}
