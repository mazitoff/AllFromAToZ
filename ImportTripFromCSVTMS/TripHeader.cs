using System;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;
using System.Data;
using System.Data.SqlClient;

namespace ImportTripFromCSVTMS
{
    class TripHeader
    {
        private const string EmptyId = "     0   ";
        private DateTime EmptyDate = DateTime.Parse("1753-01-01T00:00:00");

        public string IdTrip { get; private set; }                      // 00 [Идентификатор] [varchar] (50)
        public DateTime DateDoc { get; private set; }                   // 01 [ДатаДок] [datetime]
        public string LoadForm { get; private set; }                    // 02 [ВидОтгрузки] [char](9)
        public string TripStatus { get; private set; }                  // 03 [СтатусРейса] [varchar] (50)
        public string Customer { get; private set; }                    // 04 [Заказчик] [char](9)
        public string Shipper { get; private set; }                     // 05 [Грузоотправитель] [char](9)
        public DateTime DateStartLoadingPlan { get; private set; }      // 06 [ДатаНачалаПогрузкиПлан] [datetime]
        public int TimeSecStartLoadingPlan { get; private set; }        // 07 [ВремяНачалаПогрузкиПлан] [int]
        public DateTime DateStartLoadingRealise { get; private set; }   // 08 [ДатаНачалаПогрузкиФакт] [datetime]
        public int TimeSecStartLoadingRealise { get; private set; }     // 09 [ВремяНачалаПогрузкиФакт] [int]
        public DateTime DateFinishLoadingPlan { get; private set; }     // 10 [ДатаОкончанияПогрузкиПлан] [datetime]
        public int TimeSecFinishLoadingPlan { get; private set; }       // 11 [ВремяОкончанияПогрузкиПлан] [int]
        public DateTime DateFinishLoadingRealise { get; private set; }  // 12 [ДатаОкончанияПогрузкиФакт] [datetime]
        public int TimeSecFinishLoadingRealise { get; private set; }    // 13 [ВремяОкончанияПогрузкиФакт] [int]
        public string CarrierAutoId { get; private set; }               // 14 [АТПСсылка] [char](9)
        public string CarrierAutoName { get; private set; }             // 15 [АТП] [varchar] (500)
        public string CarrierShopId { get; private set; }               // 16 [ТЭП] [char](9)
        public string DriversName { get; private set; }                 // 17 [Водитель] [varchar] (50)
        public string DriversPassportSeries { get; private set; }       // 18 [ВодительСерияПаспорта] [varchar](50)
        public string DriversPassportNumber { get; private set; }       // 19 [ВодительНомерПаспорта] [varchar](50)
        public DateTime DriversPassportDateIssued { get; private set; } // 20 [ВодительДатаВыдачиПаспорта] [datetime]
        public string DriversPassportIssuedBy { get; private set; }     // 21 [ВодительКемВыданПаспорт] [varchar](500)
        public string DriversLicense { get; private set; }              // 22 [ВодительПрава] [varchar] (50)
        public string TruckName { get; private set; }                   // 23 [Автомобиль] [varchar] (50)
        public string TrailerName { get; private set; }                 // 24 [Прицеп] [varchar] (50)
        public string LoadingPlaceCode { get; private set; }            // 25 [МестоПогрузки] [varchar] (80)
        public string StufferId { get; private set; }                   // 26 [ГрузСдал] [char](9)
        public string LoadType { get; private set; }                    // 27 [ТипГруза] [varchar] (50)
        public string Weight { get; private set; }                      // 28 [ВесОбщий] [varchar] (50)
        public string LoadingType { get; private set; }                 // 29 [ВидПогрузки] [varchar] (50)
        public decimal SummCostPlan { get; private set; }               // 30 [СуммаФрахтПлан] [numeric] (12, 2)
        public decimal SummCostRealise { get; private set; }            // 31 [СуммаФрахтФакт] [numeric] (12, 2)
        public decimal SummSurcharge { get; private set; }              // 32 [ДопТЧДокументаЗаявкаТЭП_Сумма] [numeric] (10, 2)
        public string SurchargeComment { get; private set; }            // 33 [ДопТЧДокументаЗаявкаТЭП_Примечание] [varchar] (50)
        public string CreatedStufferId { get; private set; }            // 34 [Ответственный] [char](9) 
        public string TruckLength { get; private set; }                 // 35 [ТребАвто] [varchar] (100)
        public string DriversPhoneNumber { get; private set; }          // 36 [ТелефНомВодилы] [varchar] (50)
        public string Comment { get; private set; }                     // 37 [Примечание] [varchar] (100)
        public decimal Distance { get; private set; }                   // 38 [ОбщКилоМетраж] [numeric] (10, 0)
        public string IdCodeTruck { get; private set; }                 // 39 [ID_code_truck] [varchar] (50)
        public string IdCodeTrailer { get; private set; }               // 40 [ID_code_trailer] [varchar] (50)
        public string IdCodeDriver { get; private set; }                // 41 [ID_code_driver] [varchar] (50)

        public TripHeader(IEnumerable<string> stringFromFile)
        {
            if (stringFromFile.Count() == 37)
            {
                LoadForm = EmptyId; // ВидОтгрузки заполним на основании значений ВидовОтгрузок из Заказов ТЧ Рейса
                int count = 0;
                foreach (var unit in stringFromFile)
                {
                    switch (count++)
                    {
                        case 0: IdTrip = unit; break; // trip_code
                        case 1: DateDoc = DateTime.Parse(unit).Date; break; // created_datetime
                        case 2: TripStatus = unit; break;  // shift_status
                        case 3: Customer = GetClientId(unit); break; // transportation_client
                        case 4: Shipper = GetClientId(unit); break; // shipper
                        case 5:  // planned_pickup_stop_startInstant
                            {
                                DateStartLoadingPlan = GetDateFromString(unit);
                                TimeSecStartLoadingPlan = GetTimeSecFromString(unit);
                            }; break;
                        case 6:  // realized_pickup_stop_startInstant
                            {
                                DateStartLoadingRealise = GetDateFromString(unit);
                                TimeSecStartLoadingRealise = GetTimeSecFromString(unit);
                            }; break;
                        case 7:  // planned_pickup_stop_finishInstant
                            {
                                DateFinishLoadingPlan = GetDateFromString(unit);
                                TimeSecFinishLoadingPlan = GetTimeSecFromString(unit);
                            }; break;
                        case 8:  // realized_pickup_stop_finishInstant
                            {
                                DateFinishLoadingRealise = GetDateFromString(unit);
                                TimeSecFinishLoadingRealise = GetTimeSecFromString(unit);
                            }; break;
                        case 9: CarrierAutoId = GetCarrierId(unit); break; // resource_subcontractor_externalId
                        case 10: CarrierAutoName = unit; break; // resource_subcontractor_name
                        case 11: CarrierShopId = GetCarrierId(unit); break; // shift_subcontractor
                        case 12: DriversName = unit; break; // driver_name
                        case 13: DriversPassportSeries = unit; break; // driver_passport_series
                        case 14: DriversPassportNumber = unit; break; // driver_passport_number
                        case 15: DriversPassportDateIssued = EmptyDate  /*GetDateFromString(unit)*/; break; // driver_passport_date_issued -- Заблокировал до выяснения, что-то в ТМС накрутили с датой, если приходит дата то выдает ошибку 13.07.17
                        case 16: DriversPassportIssuedBy = unit; break; // driver_passport_issued_by
                        case 17: DriversLicense = unit; break; // driver_driver_license
                        case 18: TruckName = unit; break; // truck_name
                        case 19: TrailerName = unit; break; // trailer_name
                        case 20:  // pickup_address_externalId
                            {
                                LoadingPlaceCode = unit;
                                StufferId = GetStufferIdFromAddress(unit);
                            }; break;
                        case 21: LoadType = unit; break; // products
                        case 22: Weight = unit; break; // truck_capacity
                        case 23: LoadingType = unit; break; // addresses_delivery_capabilities
                        case 24: SummCostPlan = GetDecimalValue(unit); break; // plancost
                        case 25: SummCostRealise = GetDecimalValue(unit); break; // realcost
                        case 26: SummSurcharge = GetDecimalValue(unit); break; // surcharge
                        case 27: SurchargeComment = unit; break; // surcharge_comment
                        case 28: CreatedStufferId = GetStufferId(unit); break; // created_user
                        case 29: TruckLength = unit; break; // udf_truck_length
                        case 30: DriversPhoneNumber = unit; break; // driver_phone
                        case 31: Comment = unit; break; // shift_comment
                        // case 32: // disable_delivery_type_check не используется при загрузке
                        case 33: Distance = GetDecimalValue(unit); break; // trip_distance
                        case 34: IdCodeTruck = unit; break; // ID_code_truck
                        case 35: IdCodeTrailer = unit; break; // ID_code_trailer
                        case 36: IdCodeDriver = unit; break; // ID_code_driver
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
            if(s.Trim() == "")
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

        private static string GetClientId(string tmsId)
        {
            var result = "";
            if (tmsId == "")
            {
                result = EmptyId;
            }
            else
            {
                SqlConnection connection = new SqlConnection("context connection=true");
                using (connection)
                {
                    connection.Open();
                    string cmdText = @"select isnull((select top 1
						СК.ИдЭлемента
					from dbo.Справочник_Клиенты СК (nolock)
					where ltrim(rtrim(СК.глКод)) = @tmsId
				),dbo._1s_ПустойИд())";
                    using (var cmd = new SqlCommand(cmdText, connection))
                    {
                        var parametrTmsId = cmd.Parameters.Add("@tmsId", SqlDbType.NVarChar, 50);
                        parametrTmsId.Value = tmsId;
                        result = (string)cmd.ExecuteScalar();
                    }
                    connection.Close();
                }
            }
            return result;
        }

        private static string GetCarrierId(string tmsId)
        {
            var result = "";
            if (tmsId == "")
            {
                result = EmptyId;
            }
            else
            {
                SqlConnection connection = new SqlConnection("context connection=true");
                using (connection)
                {
                    connection.Open();
                    string cmdText = @"select isnull((select top 1
                        СП.Клиент
                    from dbo.Справочник_Перевозчики СП (nolock)
                    where ltrim(rtrim(СП.Код)) = @tmsId
                ),dbo._1s_ПустойИд())";
                    using (var cmd = new SqlCommand(cmdText, connection))
                    {
                        var parametrTmsId = cmd.Parameters.Add("@tmsId", SqlDbType.NVarChar, 50);
                        parametrTmsId.Value = tmsId;
                        result = (string)cmd.ExecuteScalar();
                    }
                    connection.Close();
                }
            }
            return result;
        }

        private static string GetStufferIdFromAddress(string tmsId)
        {
            var result = "";
            if (tmsId == "")
            {
                result = EmptyId;
            }
            else
            {
                SqlConnection connection = new SqlConnection("context connection=true");
                using (connection)
                {
                    connection.Open();
                    string cmdText = @"select isnull((select top 1
                                        СС.ИдЭлемента
                                    from dbo.Справочник_АдресаДоставки САД (nolock)
                                    inner join dbo.Справочник_ТелефоныАдресаДоставки СТАД (nolock)
                                        on СТАД.ИдВладельца = САД.ИдЭлемента
                                        and СТАД.ПометкаУдаления = 0
                                    inner join dbo.Справочник_Сотрудники СС (nolock)
                                        on СС.Наименование = СТАД.Примечание
                                        and СС.ПометкаУдаления = 0
                                    where 1 = 1
                                        and ltrim(rtrim(САД.Код)) = @tmsId
                                ),dbo._1s_ПустойИд())";
                    using (var cmd = new SqlCommand(cmdText, connection))
                    {
                        var parametrTmsId = cmd.Parameters.Add("@tmsId", SqlDbType.NVarChar, 50);
                        parametrTmsId.Value = tmsId;
                        result = (string)cmd.ExecuteScalar();
                    }
                    connection.Close();
                }
            }
            return result;
        }

        private static string GetStufferId(string tmsId)
        {
            var result = "";
            if (tmsId == "")
            {
                result = EmptyId;
            }
            else
            {
                SqlConnection connection = new SqlConnection("context connection=true");
                using (connection)
                {
                    connection.Open();
                    string cmdText = @"select isnull((select top 1
                                            СС.ИдЭлемента
                                        from Справочник_Сотрудники СС (nolock)
                                        where 1 = 1
                                            and rtrim(ltrim(СС.Код)) = @tmsId
                                            and СС.ИдРодителя = dbo._1s_ПустойИд()
                                        order by СС.ПометкаУдаления asc
                                        ),dbo._1s_ПустойИд())";
                    using (var cmd = new SqlCommand(cmdText, connection))
                    {
                        var parametrTmsId = cmd.Parameters.Add("@tmsId", SqlDbType.NVarChar, 50);
                        parametrTmsId.Value = tmsId;
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

        private static int GetTimeSecFromString(string tmsDateStr)
        {
            int result;
            if (tmsDateStr == "")
            {
                result = 0;
            }
            else
            {
                TimeSpan span = DateTime.Parse(tmsDateStr) - DateTime.Parse(tmsDateStr).Date;
                result = (int)span.TotalSeconds;
            }
            return result;
        }
    }
}
