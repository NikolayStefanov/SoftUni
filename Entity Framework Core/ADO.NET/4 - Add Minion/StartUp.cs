namespace _4___Add_Minion
{
    using Microsoft.Data.SqlClient;
    using System;
    using System.Linq;
    using System.Runtime.InteropServices.ComTypes;
    using System.Text;

    public class StartUp
    {
        private const string connectionString = "Server = DESKTOP-9UTID0E;Database=MinionsDB;Integrated Security=true";
        static void Main()
        {
            using SqlConnection sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();

            var minionsInput = Console.ReadLine().Split(": ", StringSplitOptions.RemoveEmptyEntries).ToArray();
            var minionsInfo = minionsInput[1].Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();

            var villainInput = Console.ReadLine().Split(": ", StringSplitOptions.RemoveEmptyEntries).ToArray();
            var villainName = villainInput[1];

            var result = AddMinionsToDatabase(sqlConnection, minionsInfo, villainName);
            Console.WriteLine(result);
        }

        private static string AddMinionsToDatabase(SqlConnection sqlConnection, string[] minionsInfo, string villainName)
        {
            StringBuilder output = new StringBuilder();
            var minionName = minionsInfo[0];
            var minionAge = int.Parse(minionsInfo[1]);
            var targetTown = minionsInfo[2];

            string townId = IsTownExists(sqlConnection, targetTown, output);
            string villainId = IsVillainExists(sqlConnection, villainName, output);

            string minionId = InsertNewMinionInDatabase(sqlConnection, minionName, minionAge, townId);

            var makeMinionServingQuery = "INSERT INTO MinionsVillains VALUES(@minionId, @villainId)";
            var makeMinionServingCmd = new SqlCommand(makeMinionServingQuery, sqlConnection);
            makeMinionServingCmd.Parameters.AddWithValue("@minionId", int.Parse(minionId));
            makeMinionServingCmd.Parameters.AddWithValue("@villainId", int.Parse(villainId));
            makeMinionServingCmd.ExecuteNonQuery();

            output.AppendLine($"Successfully added {minionName} to be minion of {villainName}.");

            return output.ToString().TrimEnd();
        }

        private static string InsertNewMinionInDatabase(SqlConnection sqlConnection, string minionName, int minionAge, string townId)
        {
            var newMinionIdQuery = "SELECT Id FROM Minions WHERE [Name] = @minionName";
            var selectNewMinionIdCmd = new SqlCommand(newMinionIdQuery, sqlConnection);
            selectNewMinionIdCmd.Parameters.AddWithValue("@minionName", minionName);
            var minionId = selectNewMinionIdCmd.ExecuteScalar()?.ToString();

            if (minionId == null)
            {
                var insertTheNewMinionQuery = $"INSERT INTO Minions([Name], Age, TownId) VALUES(@minionName, @minionAge, @townId)";
                var insertNewMinionSqlCmd = new SqlCommand(insertTheNewMinionQuery, sqlConnection);
                insertNewMinionSqlCmd.Parameters.AddWithValue("@minionName", minionName);
                insertNewMinionSqlCmd.Parameters.AddWithValue("@minionAge", minionAge);
                insertNewMinionSqlCmd.Parameters.AddWithValue("@townId", int.Parse(townId));

                insertNewMinionSqlCmd.ExecuteNonQuery();
                minionId = selectNewMinionIdCmd.ExecuteScalar()?.ToString();
            }
            
            return minionId;
        }

        private static string IsVillainExists(SqlConnection sqlConnection, string villainName, StringBuilder output)
        {
            var getVillainIdQuery = $"SELECT Id FROM Villains WHERE [Name] = @villainName";
            using SqlCommand getVillainIdCmd = new SqlCommand(getVillainIdQuery, sqlConnection);
            getVillainIdCmd.Parameters.AddWithValue("@villainName", villainName);

            var villainId = getVillainIdCmd.ExecuteScalar()?.ToString();
            if (villainId == null)
            {
                var insertNewVillainQuery = "INSERT INTO Villains([Name], EvilnessFactorId) VALUES(@villainName, 4)";
                using SqlCommand insertNewVillainCmw = new SqlCommand(insertNewVillainQuery, sqlConnection);
                insertNewVillainCmw.Parameters.AddWithValue("@villainName", villainName);
                insertNewVillainCmw.ExecuteNonQuery();

                villainId = getVillainIdCmd.ExecuteScalar()?.ToString();
                output.AppendLine($"Villain {villainName} was added to the database.");
            }
            return villainId;
        }

        private static string IsTownExists(SqlConnection sqlConnection, string targetTown, StringBuilder output)
        {
            var getTownIdQueryText = $"SELECT Id FROM Towns WHERE [Name] = @townName";
            using SqlCommand getTownIdCmd = new SqlCommand(getTownIdQueryText, sqlConnection);
            getTownIdCmd.Parameters.AddWithValue("@townName", targetTown);

            var townId = getTownIdCmd.ExecuteScalar()?.ToString();
            if (townId == null)
            {
                var insertIntoTownsQuery = $"INSERT INTO Towns([Name], CountryCode) VALUES(@townName, 'BG')";
                using SqlCommand insertIntoTownsCmd = new SqlCommand(insertIntoTownsQuery, sqlConnection);
                insertIntoTownsCmd.Parameters.AddWithValue("@townName", targetTown);
                insertIntoTownsCmd.ExecuteNonQuery();
                townId = getTownIdCmd.ExecuteScalar()?.ToString();
                output.AppendLine($"Town {targetTown} was added to the database.");
            }
            return townId;

        }
    }
}
