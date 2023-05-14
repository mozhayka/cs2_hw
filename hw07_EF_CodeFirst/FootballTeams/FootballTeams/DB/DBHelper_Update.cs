using System;
using System.Numerics;
using System.Xml.Linq;

namespace FootballTeams.DB
{
    internal partial class DBHelper
    {
        public void ScoreGoal(Player player)
        {
            using var transaction = db.Database.BeginTransaction();
            try
            {
                db.Database.ExecuteSqlCommand(@$"UPDATE Players SET 
                    NumberOfGoals = NumberOfGoals + 1 WHERE Id = '{player.Id}'");
                db.Database.ExecuteSqlCommand(@$"UPDATE Stats SET 
                    AvgGoals = AvgGoals + (1 / NumberOfPlayers) WHERE Id = {player.TeamId}");

                db.SaveChanges();
                transaction.Commit();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                Console.WriteLine(ex.Message);
            }
        }
    }
}