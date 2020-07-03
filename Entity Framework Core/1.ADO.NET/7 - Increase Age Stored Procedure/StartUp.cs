using Microsoft.Data.SqlClient;
using System;
using System.Data;

namespace _7___Increase_Age_Stored_Procedure
{
    public class StartUp
    {
        private const string connectionString = "Server = DESKTOP-9UTID0E;Database=MinionsDB;Integrated Security=true";
        static void Main()
        {
            using SqlConnection sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();

            var input = int.Parse(Console.ReadLine());
            var executeProcedureQuery = "usp_GetOlder";
            var executeProcedureCmd = new SqlCommand(executeProcedureQuery, sqlConnection);
            executeProcedureCmd.CommandType = CommandType.StoredProcedure;
            executeProcedureCmd.Parameters.AddWithValue("@minionID", input);
            executeProcedureCmd.ExecuteNonQuery();

            var showUpdatedMinionInfo = "SELECT [Name], Age FROM Minions WHERE Id = @input";
            var showUpdateMinionCmd = new SqlCommand(showUpdatedMinionInfo, sqlConnection);
            showUpdateMinionCmd.Parameters.AddWithValue("@input", input);

            using var minionReader = showUpdateMinionCmd.ExecuteReader();
            minionReader.Read();
            var minionName = minionReader["Name"].ToString();
            var minionAge = minionReader["Age"].ToString();

            Console.WriteLine($"{minionName} - {minionAge} years old");
        }
    }
}
