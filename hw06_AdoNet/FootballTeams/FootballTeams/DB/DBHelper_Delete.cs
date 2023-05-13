using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace FootballTeams
{
    internal partial class DBHelper
    {
        public void DeletePlayer(string name)
        {
            using SqlConnection connection = new(connectionString);
            connection.Open();
            SqlTransaction transaction = connection.BeginTransaction();

            SqlCommand command = connection.CreateCommand();
            command.Transaction = transaction;

            try
            {
                command.CommandText = $"SELECT PlayerID FROM Player WHERE FirstName = '{name}'";
                int PlayerID = int.Parse(command.ExecuteScalar().ToString());
                command.CommandText = $"SELECT TeamID FROM Player WHERE FirstName = '{name}'";
                int TeamID = int.Parse(command.ExecuteScalar().ToString());
                command.CommandText = $"SELECT AddressID FROM Player WHERE FirstName = '{name}'";
                int AddressID = int.Parse(command.ExecuteScalar().ToString());

                command.CommandText = $"DELETE FROM Player WHERE FirstName = '{name}'";
                command.ExecuteNonQuery();
                command.CommandText = $"DELETE FROM Address WHERE AddressID = {AddressID}";
                command.ExecuteNonQuery();
                command.CommandText = $"UPDATE Stats SET " +
                    $"AvgGoals = AvgGoals * NumberOfPlayers / (NumberOfPlayers - 1), " +
                    $"NumberOfPlayers = NumberOfPlayers - 1 " +
                    $"WHERE TeamID={TeamID}";
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

        public void ClearAll()
        {
            using SqlConnection connection = new(connectionString);
            connection.Open();
            SqlTransaction transaction = connection.BeginTransaction();

            SqlCommand command = connection.CreateCommand();
            command.Transaction = transaction;

            try
            {                      
                command.CommandText = $"DELETE FROM Player";
                command.ExecuteNonQuery();          
                command.CommandText = $"DELETE FROM Address";
                command.ExecuteNonQuery();

                command.CommandText = $"DELETE FROM Stats";
                command.ExecuteNonQuery();                
                command.CommandText = $"DELETE FROM Team_Stadium";
                command.ExecuteNonQuery();

                command.CommandText = $"DELETE FROM Team";
                command.ExecuteNonQuery();
                
                command.CommandText = $"DELETE FROM Stadium";
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
    }
}
