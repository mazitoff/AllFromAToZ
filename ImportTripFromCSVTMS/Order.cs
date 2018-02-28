using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Data;
using System.Globalization;

namespace ImportTripFromCSVTMS
{

    class Order
    {
        private const string EmptyId = "     0   ";
        private const string EmptyId13 = "   0     0   ";
        private const string EnumLoadFormInterDepot = "   7EW   ";
        private const string EnumLoadFormToCrossDoc = "   7ET   ";
        private const string EnumLoadFormToClient = "   7ES   ";
        private const string EnumLoadFormFromCrossDoc = "   7EU   ";
        private const string EnumLoadFormSendParsel = "   82D   ";
        private const string EnumLoadFormRecieveParcel = "   82E   ";

        public string OrderId { get; private set; }
        public DateTime DateOfArrivalPlan { get; private set; }
        public string TimeOfArrivalPlan { get; private set; }
        public DateTime DateOfArrivalRealise { get; private set; }
        public string TimeOfArrivalRealise { get; private set; }
        public DateTime DateOfDeparturePlan { get; private set; }
        public string TimeOfDeparturePlan { get; private set; }
        public DateTime DateOfDepartureRealise { get; private set; }
        public string TimeOfDepartureRealise { get; private set; }
        public string LoadForm { get; private set; }
        public decimal OrderVisitation { get; private set; }
        public decimal Distance { get; private set; }

        public Order(IEnumerable<string> stringFromFile)
        {
            if (stringFromFile.Count() == 8)
            {
                int count = 0;
                foreach (var unit in stringFromFile)
                {
                    switch (count++)
                    {
                        case 0: OrderId = GetDocumentId(unit); break;
                        case 1: LoadForm = GetLoadForm(unit); break;
                        case 2:
                            {
                                DateOfArrivalPlan = GetDateFromString(unit);
                                TimeOfArrivalPlan = GetTimeStrFromString(unit);
                            }; break;
                        case 3:
                            {
                                DateOfDeparturePlan = GetDateFromString(unit);
                                TimeOfDeparturePlan = GetTimeStrFromString(unit);
                            }; break;
                        case 4:
                            {
                                DateOfArrivalRealise = GetDateFromString(unit);
                                TimeOfArrivalRealise = GetTimeStrFromString(unit);
                            }; break;
                        case 5:
                            {
                                DateOfDepartureRealise = GetDateFromString(unit);
                                TimeOfDepartureRealise = GetTimeStrFromString(unit);
                            }; break;
                        case 6: OrderVisitation = GetDecimalValue(unit); break;
                        case 7: Distance = GetDecimalValue(unit); break;
                    }
                }
            }
            else
            {
                //throw Exception();
            }
        }

        private static decimal GetDecimalValue(string s)
        {
            decimal result;
            if (s.Trim() == "")
            {
                result = 0m;
            }
            else
            {
                try
                {
                    result = Decimal.Parse(s, NumberStyles.Any, CultureInfo.InvariantCulture);
                }
                catch
                {
                    result = 0m;
                }
            }
            return result;
        }

        private static string GetLoadForm(string tmsStr)
        {
            string result = EmptyId;
            switch (tmsStr)
            {
                case "InterDepot": result = EnumLoadFormInterDepot; break;
                case "ToCrossdock": result = EnumLoadFormToCrossDoc; break;
                case "DirectDelivery": result = EnumLoadFormToClient; break;
                case "FromCrossdock": result = EnumLoadFormFromCrossDoc; break;
                case "CourierDelivery": result = EnumLoadFormSendParsel; break;
                case "CourierReturn": result = EnumLoadFormRecieveParcel; break;
                default: result = EmptyId; break;
            }
            return result;
        }

        private static string GetDocumentId(string documentCode)
        {
            var result = EmptyId13;
            if (documentCode == "")
            {
                result = EmptyId13;
            }
            else
            {
                SqlConnection connection = new SqlConnection("context connection=true");
                using (connection)
                {
                    connection.Open();
                    string cmdText = @"select isnull((SELECT TOP 1 
								Right(dbo.IntToChar36(Журнал.ВидДокумента),4)+Д.Документ
							 FROM dbo._1s_TMS_Документы AS Д (NOLOCK)
							 INNER JOIN dbo.Журнал AS Журнал (NOLOCK)
								ON Журнал.ИдДокумента = Д.Документ
							 WHERE Д.ИдТМС = @tmsId),dbo._1s_ПустойИд13())";
                    using (var cmd = new SqlCommand(cmdText, connection))
                    {
                        var parametrTmsId = cmd.Parameters.Add("@tmsId", SqlDbType.NVarChar, 50);
                        parametrTmsId.Value = documentCode;
                        result = (string)cmd.ExecuteScalar();
                    }
                    connection.Close();
                }
            }
            return result;
        }

        private static DateTime GetDateFromString(string tmsDateStr)
        {
            DateTime result;
            switch (tmsDateStr)
            {
                case "": { result = DateTime.Parse("1753-01-01T00:00:00"); } break;
                default: result = DateTime.Parse(tmsDateStr).Date; break;
            }
            return result;
        }

        private static string GetTimeStrFromString(string tmsDateStr)
        {
            string result;
            if (tmsDateStr == "")
            {
                result = "00:00";
            }
            else
            {
                result = tmsDateStr.Substring(12, 5);
            }
            return result;
        }
    }
}
