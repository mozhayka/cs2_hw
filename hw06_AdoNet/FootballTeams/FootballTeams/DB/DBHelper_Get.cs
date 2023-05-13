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

                CommandText = $"SELECT TeamID FROM Team WHERE TeamName = '{team.Name}'"
            };

            int addressID = int.Parse(command.ExecuteScalar().ToString());
            return addressID;
        }

        public void PrintTeamPlayers(Team team)
        {
            string sqlExpression = "sp_GetTeamPlayers";

            using SqlConnection connection = new(connectionString);
            connection.Open();
            SqlCommand command = new(sqlExpression, connection)
            {
                CommandType = System.Data.CommandType.StoredProcedure
            };

            SqlParameter teamIDParam = new()
            {
                ParameterName = "@teamID",
                Value = GetTeamId(team)
            };
            command.Parameters.Add(teamIDParam);

            var reader = command.ExecuteReader();
            if (reader.HasRows)
            {

                while (reader.Read())
                {
                    string firstName = reader.GetString(1);
                    string lastName = reader.GetString(2);
                    Console.WriteLine($"{firstName} {lastName}");
                }
            }
            reader.Close();
        }
    }
}
