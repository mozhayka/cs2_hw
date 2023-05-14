using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballTeams.DB
{
    internal partial class DBHelper
    {
        readonly FootballContext db = new();

        public void AddPlayer(Player player)
        {
            db.Players.Add(player);
            db.SaveChanges();
        }

        public void AddTeam(Team team)
        {
            db.Teams.Add(team);
            db.SaveChanges();
        }

        public void AddStadium(Stadium stadium)
        {
            db.Stadiums.Add(stadium);
            db.SaveChanges();
        }

        public void AddPlayer_Team(Player player, Team team)
        {
            player.Team = team;

            team.Stats.AvgGoals = (team.Stats.AvgGoals * team.Stats.NumberOfPlayers + player.NumberOfGoals) / (team.Stats.NumberOfPlayers + 1);
            team.Stats.NumberOfPlayers++;

            db.Entry(team).State = EntityState.Modified;
            db.Entry(player).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void AddTeam_Stadium(Team team, Stadium stadium)
        {
            team.Stadiums.Add(stadium);
            team.Stats.NumberOfStadiums++;

            db.Entry(team).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}
