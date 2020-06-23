using Microsoft.Data.SqlClient;
using System;
using System.Text;

namespace _3___Minion_Names
{
    class Program
    {
        static void Main(string[] args)
        {
            SqlConnection sqlConnection = new SqlConnection("Server = DESKTOP-9UTID0E;Database=MinionsDB;Integrated Security=true");
            using (sqlConnection)
            {
                sqlConnection.Open();
                var input = int.Parse(Console.ReadLine());
                var result = new StringBuilder();

                var minionsNamesCommand = $"SELECT * FROM Villains WHERE Id = @input";
                SqlCommand scalarExe = new SqlCommand(minionsNamesCommand, sqlConnection);
                scalarExe.Parameters.AddWithValue("@input", input);
                if (scalarExe.ExecuteScalar()?.ToString() != null)
                {
                    var villainNameCommand = $"SELECT [Name] FROM Villains WHERE Id = @input";
                    var villainNameSqlCommand = new SqlCommand(villainNameCommand, sqlConnection);
                    villainNameSqlCommand.Parameters.AddWithValue("@input", input);
                    using (SqlDataReader villainReader = villainNameSqlCommand.ExecuteReader())
                    {
                        villainReader.Read();
                        var theVillainName = villainReader["Name"].ToString();
                        result.AppendLine($"Villain: {theVillainName}");
                    }
                    var getMinionsNameCommand = $"SELECT * FROM  MinionsVillains AS mv JOIN Minions AS m ON mv.MinionId = m.Id WHERE MV.VillainId = @input";

                    SqlCommand minionsCountCheck = new SqlCommand(getMinionsNameCommand, sqlConnection);
                    minionsCountCheck.Parameters.AddWithValue("@input", input);
                    if (minionsCountCheck.ExecuteScalar() != null)
                    {
                        SqlCommand getMinionsNamesExe = new SqlCommand(getMinionsNameCommand, sqlConnection);
                        getMinionsNamesExe.Parameters.AddWithValue("@input", input);
                        using (SqlDataReader minionsNamesReader = getMinionsNamesExe.ExecuteReader())
                        {
                            while (minionsNamesReader.Read())
                            {
                                var minionId = (int)minionsNamesReader["Id"];
                                var minionName = minionsNamesReader["Name"].ToString();
                                var minionAge = (int)minionsNamesReader["Age"];
                                result.AppendLine($"{minionId}. {minionName} {minionAge}");
                            }
                        }
                    }
                    else
                    {
                        result.AppendLine("(no minions)");
                    }

                }
                else
                {
                    result.AppendLine($"No villain with ID {input} exists in the database.");
                }

                Console.WriteLine(result);
            }
        }
    }
}
