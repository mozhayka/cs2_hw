using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

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
                    "VALUES(@Country, @City, @Street, @Building, @Apartment);SET @id=SCOPE_IDENTITY()";

                command.Parameters.Add(new SqlParameter("@Country", player.Addr.Country));
                command.Parameters.Add(new SqlParameter("@City", player.Addr.City));
                command.Parameters.Add(new SqlParameter("@Street", player.Addr.Street));
                command.Parameters.Add(new SqlParameter("@Building", player.Addr.Building));
                command.Parameters.Add(new SqlParameter("@Apartment", player.Addr.Apartment));

                // параметр для id
                SqlParameter idParam = new()
                {
                    ParameterName = "@id",
                    SqlDbType = SqlDbType.Int,
                    Direction = ParameterDirection.Output // параметр выходной
                };
                command.Parameters.Add(idParam);
                command.ExecuteNonQuery();


                command.CommandText = "INSERT INTO Player (FirstName, SecondName, AddressID, TeamID, NumberOfGoals) " +
                    "VALUES(@FirstName, @SecondName, @Street, @AddressID, @TeamID, @NumberOfGoals);SET @id=SCOPE_IDENTITY()";

                command.Parameters.Add(new SqlParameter("@FirstName", player.FirstName));
                command.Parameters.Add(new SqlParameter("@SecondName", player.SecondName));
                command.Parameters.Add(new SqlParameter("@AddressID", idParam.Value));
                command.Parameters.Add(new SqlParameter("@TeamID", GetTeamId(player.Team)));
                command.Parameters.Add(new SqlParameter("@NumberOfGoals", player.NumberOfGoals));
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

        }

        public void AddStadium(Stadium stadium)
        {
            using SqlConnection connection = new(connectionString);
            string sqlExpression = $"INSERT INTO Stadium (Name) VALUES ('{stadium.Name}')";
            SqlCommand command = new(sqlExpression, connection);
            command.ExecuteNonQuery();
        }
}
