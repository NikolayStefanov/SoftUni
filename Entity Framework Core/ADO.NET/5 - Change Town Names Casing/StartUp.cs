using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;

namespace _5___Print_All_Minion_Names
{
    public class StartUp
    {
        private const string connectionString = "Server = DESKTOP-9UTID0E;Database=MinionsDB;Integrated Security=true";
        static void Main()
        {
            using SqlConnection sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();

            var countOfMinions = GetCountOfMinions(sqlConnection);
            var allMinionNames = new List<string>();

            var printAllMinionsQuery = "SELECT [Name] FROM Minions";
            var printAllminionsCmd = new SqlCommand(printAllMinionsQuery, sqlConnection);

            using var reader = printAllminionsCmd.ExecuteReader();
            while (reader.Read())
            {
                var name = reader["Name"].ToString();
                allMinionNames.Add(name);
            }

            for (int i = 0; i < allMinionNames.Count/2; i++)
            {
                Console.WriteLine(allMinionNames[i]);
                Console.WriteLine(allMinionNames[(allMinionNames.Count-1)-i]);
            }

        }

        private static int GetCountOfMinions(SqlConnection sqlConnection)
        {
            var countOfEntitiesQuery = "SELECT COUNT(*) FROM Minions";
            var countOfEntitiesCmd = new SqlCommand(countOfEntitiesQuery, sqlConnection);
            var countOfMinions = countOfEntitiesCmd.ExecuteScalar()?.ToString();
            if (countOfMinions == null)
            {
                throw new InvalidOperationException("There isn't any Minions in the Database!");
            }
            return int.Parse(countOfMinions);
        }
    }
}
