using Microsoft.Data.SqlClient;
using System;

namespace _2___Villain_Names
{
    class StartUp
    {
        static void Main(string[] args)
        {
            SqlConnection sqlConnection = new SqlConnection("Server = DESKTOP-9UTID0E;Database=MinionsDB;Integrated Security=true");
            using (sqlConnection)
            {
                sqlConnection.Open();
                var villainsNamesCommand = "SELECT  v.Name, COUNT(mv.MinionId) AS [Count] " +
                           "FROM MinionsVillains AS mv JOIN Villains AS v ON mv.VillainId = v.Id  " +
                           "GROUP BY v.Id, v.Name ORDER BY[Count] DESC";

                var getVillainsMinionsCount = new SqlCommand(villainsNamesCommand, sqlConnection);

                using (SqlDataReader reader = getVillainsMinionsCount.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var villainsName = reader["Name"].ToString();
                        var minionsCount = (int)reader["Count"];
                        Console.WriteLine($"{villainsName} - {minionsCount}");
                    }
                }
            }
        }
    }
}
