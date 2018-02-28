using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.IO;

namespace ImportTripFromCSVTMS
{
    public class Import
    {
        protected static string PathToTMSDirectory { get; private set; }

        public static void Start()
        {
            PathToTMSDirectory = GetPathToTMSDirectory();
            IEnumerable<string> fileNames = FileNames();
            foreach (var fileName in fileNames)
            {
                Trip trip = new Trip(fileName);
                // сохранить данные Рейса в таблицы
                System.Int64 gatewayId = Inserter.Header(trip.Header);
                if(gatewayId != -1)
                {
                    Inserter.Lines(gatewayId, trip.Lines);
                }
                // переименовать файл, для последующей его перемещения в архивный каталог
            }
        }

        private static string GetPathToTMSDirectory()
        {
            var pathResult = "";
            SqlConnection connection = new SqlConnection("context connection=true");
            using (connection)
            {
                connection.Open();
                string cmdText = @"select PathToTMSDirectory from dbo._1s_TMSSettings (nolock)";
                using (var cmd01 = new SqlCommand(cmdText, connection))
                {
                    pathResult = (string)cmd01.ExecuteScalar();
                }
                connection.Close();
            }
            return pathResult;
        }

        public static IEnumerable<string> FileNames()
        {
            var fileNames = Directory.GetFiles(PathToTMSDirectory, "*.csv", 0);
            return fileNames;
        }

    }
}
