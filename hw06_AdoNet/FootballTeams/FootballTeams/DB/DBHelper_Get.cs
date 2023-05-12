using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballTeams
{
    internal partial class DBHelper
    {
        public int GetTeamId(Team team)
        {
            using SqlConnection connection = new(connectionString);
            connection.Open();
            SqlCommand command = new()
            {
                Connection = connection,

                CommandText = $"SELECT TeamID FROM Team WHERE Name = {team.Name}"
            };
            int addressID = int.Parse(command.ExecuteScalar().ToString());
            return addressID;
        }
    }
}
