using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Microsoft.VisualBasic;

namespace FootballTeams
{
    internal partial class DBHelper
    {
        private readonly string connectionString;

        public DBHelper(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void AddPlayer(Player player)
        {
            using SqlConnection connection = new(connectionString);
            connection.Open();
            SqlTransaction transaction = connection.BeginTransaction();

            SqlCommand command = connection.CreateCommand();
            command.Transaction = transaction;

            try
            {
                command.CommandText = "INSERT INTO Address (Country, City, Street, Building, Apartment) " +
                    "VALUES(@Country, @City, @Street, @Building, @Apartment);SET @AddressID=SCOPE_IDENTITY()";

                command.Parameters.Add(new SqlParameter("@Country", player.Addr.Country));
                command.Parameters.Add(new SqlParameter("@City", player.Addr.City));
                command.Parameters.AddWithValue("@Street", player.Addr.Street);
                command.Parameters.Add(new SqlParameter("@Building", player.Addr.Building));
                command.Parameters.Add(new SqlParameter("@Apartment", player.Addr.Apartment));

                // параметр для id
                SqlParameter idParam = new()
                {
                    ParameterName = "@AddressID",
                    SqlDbType = SqlDbType.Int,
                    Direction = ParameterDirection.Output // параметр выходной
                };
                command.Parameters.Add(idParam);
                command.ExecuteNonQuery();
                command.Parameters.Clear();


                var AddressID = idParam.Value;
                var TeamID = GetTeamId(player.Team);
                command.CommandText = "INSERT INTO Player (FirstName, SecondName, AddressID, TeamID, NumberOfGoals) " +
                    "VALUES(@FirstName, @SecondName, @AddressID, @TeamID, @NumberOfGoals)";

                command.Parameters.Add(new SqlParameter("@FirstName", player.FirstName));
                command.Parameters.Add(new SqlParameter("@SecondName", player.SecondName));
                command.Parameters.Add(new SqlParameter("@AddressID", AddressID));
                command.Parameters.Add(new SqlParameter("@TeamID", TeamID));
                command.Parameters.Add(new SqlParameter("@NumberOfGoals", player.NumberOfGoals));
                command.ExecuteNonQuery();
                command.Parameters.Clear();


                command.CommandText = "UPDATE Stats SET " +
                    $"AvgGoals = (AvgGoals * NumberOfPlayers + {player.NumberOfGoals}) / (NumberOfPlayers + 1), " +
                    "NumberOfPlayers = NumberOfPlayers + 1 " +
                    $"WHERE TeamID = {TeamID}";

                command.ExecuteNonQuery();

                // подтверждаем транзакцию
                transaction.Commit();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                transaction.Rollback();
            }
        }

        public void AddTeam(Team team)
        {
            using SqlConnection connection = new(connectionString);
            connection.Open();
            SqlTransaction transaction = connection.BeginTransaction();

            SqlCommand command = connection.CreateCommand();
            command.Transaction = transaction;

            try
            {
                command.CommandText = "INSERT INTO Team (TeamName, EstYear) " +
                    "VALUES(@TeamName, @EstYear);SET @TeamID=SCOPE_IDENTITY()";

                command.Parameters.Add(new SqlParameter("@TeamName", team.Name));
                command.Parameters.Add(new SqlParameter("@EstYear", team.EstYear));

                // параметр для id
                SqlParameter idParam = new()
                {
                    ParameterName = "@TeamID",
                    SqlDbType = SqlDbType.Int,
                    Direction = ParameterDirection.Output // параметр выходной
                };
                command.Parameters.Add(idParam);
                command.ExecuteNonQuery();
                command.Parameters.Clear();

                command.CommandText = "INSERT INTO Stats (TeamID, NumberOfPlayers, NumberOfStadiums, AvgGoals) " +
                    "VALUES(@TeamID, @NumberOfPlayers, @NumberOfStadiums, @AvgGoals)";

                command.Parameters.Add(new SqlParameter("@TeamID", idParam.Value));
                command.Parameters.AddWithValue("@NumberOfPlayers", 0);
                command.Parameters.AddWithValue("@NumberOfStadiums", 0);
                command.Parameters.AddWithValue("@AvgGoals", 0);

                command.ExecuteNonQuery();

                // подтверждаем транзакцию
                transaction.Commit();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                transaction.Rollback();
            }
        }

        public void AddStadium(Stadium stadium)
        {
            using SqlConnection connection = new(connectionString);
            connection.Open();

            string sqlExpression = $"INSERT INTO Stadium (StadiumName) VALUES ('{stadium.Name}')";
            SqlCommand command = new(sqlExpression, connection);
            command.ExecuteNonQuery();
        }
    }
}
