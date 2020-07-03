using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;

namespace Exercise_1
{
    class Program
    {
        static void Main(string[] args)
        {
            SqlConnection sqlConnection = new SqlConnection("Server = DESKTOP-9UTID0E;Database=MinionsDB;Integrated Security=true");
            using (sqlConnection)
            {
                sqlConnection.Open();

                var insertCountries = "INSERT INTO Countries([Name]) VALUES('Bulgaria'), ('USA'),('Jordania'),('Macedonya'),('Spain')";

                var insertTowns = "INSERT INTO Towns([Name], CountryCode) VALUES('Botevgrad','BG'),('Petra', 'JD'),('Scopje', 'MC')," +
                                                                               "('Washington', 'US'),('Madrid', 'SP')";

                var insertMinions = "INSERT INTO Minions([Name], Age, TownId) VALUES('Koko', 23, 1),('Paolinka', 23, 2),('Daniel', 17, 1)," +
                                                                                   "('Elsa J.', 25, 4),('Fernando T.', 33, 5)";

                var insertEvilnessFactors = "INSERT INTO EvilnessFactors([Name]) VALUES('super good'),('good'),('bad'),('evil'),('super evil')";

                var insertVillains = "INSERT INTO Villains([Name], EvilnessFactorId) VALUES('Tihomir', 5),('Petko', 5),('Nikolay', 1)," +
                                                                                          "('Vladimir', 3),('Dankata', 3)";

                var insertVillainsMinions = "INSERT INTO MinionsVillains VALUES(1,3), (3,5), (4,4), (2,3), (5,1)";

                var insertList = new List<string>();
                insertList.Add(insertCountries);
                insertList.Add(insertTowns);
                insertList.Add(insertMinions);
                insertList.Add(insertEvilnessFactors);
                insertList.Add(insertVillains);
                insertList.Add(insertVillainsMinions);

                foreach (var insert in insertList)
                {
                    SqlCommand insertSqlCommand = new SqlCommand(insert, sqlConnection);
                    int result = (int)insertSqlCommand.ExecuteNonQuery();
                    Console.WriteLine("Affected rows: " + result);
                }


            }
        }
    }
}
