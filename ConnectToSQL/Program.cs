using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ConnectToSQL
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = @"Data Source=DESKTOP-BQCBI5O; Initial Catalog=local_base; Integrated Security=true;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                Console.WriteLine(connection.State);
                Console.WriteLine(connection.Database);

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "select * from [dbo].[tbl_test1]";
                var reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    Console.WriteLine(reader.GetName(0) + " - " + reader.GetName(1));
                    while (reader.Read())
                    {
                        Console.WriteLine(reader.GetValue(0) + " - " + reader.GetValue(1));
                    }
                }

                connection.Dispose();
                connection.Close();
            }

            Console.ReadKey();
        }
    }
}
