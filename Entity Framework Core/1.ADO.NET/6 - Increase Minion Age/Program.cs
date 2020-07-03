namespace _6___Increase_Minion_Age
{
    using Microsoft.Data.SqlClient;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        private const string connectionString = "Server = DESKTOP-9UTID0E;Database=MinionsDB;Integrated Security=true";
        static void Main()
        {
            using var sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();
            var idsToUpdate = Console.ReadLine();

            UpdateAgeOfGivenMinons(sqlConnection, idsToUpdate);
            PrintAllMinionsNameAndAge(sqlConnection);

        }

        private static void PrintAllMinionsNameAndAge(SqlConnection sqlConnection)
        {
            var printMinionsInfoQuery = "SELECT [Name], Age FROM Minions";
            var printMinionsInfoCmd = new SqlCommand(printMinionsInfoQuery, sqlConnection);
            using var minionReader = printMinionsInfoCmd.ExecuteReader();
            while (minionReader.Read())
            {
                var minionName = minionReader["Name"].ToString();
                var minionAge = minionReader["Age"].ToString();
                Console.WriteLine($"{minionName} {minionAge}");
            }
        }

        private static void UpdateAgeOfGivenMinons(SqlConnection sqlConnection, string idsToUpdate)
        {
            var ids = idsToUpdate.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse);
            foreach (var id in ids)
            {
                var updateQuery = "UPDATE Minions SET Age += 1 WHERE Id IN (@inputIds)";
                var updateCmd = new SqlCommand(updateQuery, sqlConnection);
                updateCmd.Parameters.AddWithValue("@inputIds", id);
                updateCmd.ExecuteNonQuery();
            }
            

        }
    }
}
