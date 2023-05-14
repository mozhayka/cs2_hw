namespace FootballTeams.DB
{
    internal partial class DBHelper
    {
        public void DeletePlayer(Player player)
        {
            Address address = db.Addresses.First(p => p.Id == player.Id);
            var team = player.Team;
            team.Stats.AvgGoals = (team.Stats.AvgGoals * team.Stats.NumberOfPlayers - player.NumberOfGoals) / (team.Stats.NumberOfPlayers - 1);
            team.Stats.NumberOfPlayers--;

            db.Addresses.Remove(address);
            db.Players.Remove(player);
            db.SaveChanges();
        }

        public void DeleteTeam_Stadium(Team team, Stadium stadium)
        {
            team.Stadiums.Remove(stadium);
            team.Stats.NumberOfStadiums--;
            db.SaveChanges();
        }
    }
}
