using System.Data;
using System.Data.SqlClient;

namespace ImportTripFromCSVTMS
{
    static class Inserter
    {
        public static System.Int64 Header(TripHeader header)
        {
            System.Int64 result;
            try
            {
                SqlConnection connection = new SqlConnection("context connection=true");
                using (connection)
                {
                    connection.Open();
                    using (var sqlTrans = connection.BeginTransaction()) //one transaction instead of many from each insert implicit
                    {
                        var cmdText01 = @"INSERT INTO [dbo].[_1s_TMS_Import_ЗаявкаТЭП_ш]
                                   ([СтатусШлюза]
                                   ,[ДатаВремяИзменения]
                                   ,[Идентификатор]
                                   ,[ДатаДок]
                                   ,[ВидОтгрузки]
                                   ,[СтатусРейса]
                                   ,[Заказчик]
                                   ,[Грузоотправитель]
                                   ,[ДатаНачалаПогрузкиПлан]
                                   ,[ВремяНачалаПогрузкиПлан]
                                   ,[ДатаНачалаПогрузкиФакт]
                                   ,[ВремяНачалаПогрузкиФакт]
                                   ,[ДатаОкончанияПогрузкиПлан]
                                   ,[ВремяОкончанияПогрузкиПлан]
                                   ,[ДатаОкончанияПогрузкиФакт]
                                   ,[ВремяОкончанияПогрузкиФакт]
                                   ,[АТПСсылка]
                                   ,[АТП]
                                   ,[ТЭП]
                                   ,[Водитель]
                                   ,[ВодительСерияПаспорта]
                                   ,[ВодительНомерПаспорта]
                                   ,[ВодительДатаВыдачиПаспорта]
                                   ,[ВодительКемВыданПаспорт]
                                   ,[ВодительПрава]
                                   ,[Автомобиль]
                                   ,[Прицеп]
                                   ,[МестоПогрузки]
                                   ,[ГрузСдал]
                                   ,[ТипГруза]
                                   ,[ВесОбщий]
                                   ,[ВидПогрузки]
                                   ,[СуммаФрахтПлан]
                                   ,[СуммаФрахтФакт]
                                   ,[ДопТЧДокументаЗаявкаТЭП_Сумма]
                                   ,[ДопТЧДокументаЗаявкаТЭП_Примечание]
                                   ,[Ответственный]
                                   ,[ТребАвто]
                                   ,[ТелефНомВодилы]
                                   ,[Примечание]
                                   ,[ОбщКилоМетраж]
                                   ,[ID_code_truck]
                                   ,[ID_code_trailer]
                                   ,[ID_code_driver]
                                   ,[РоботИмпортер])
                             VALUES
                                   ('P'
                                   ,getdate()
                                   ,@Идентификатор
                                   ,@ДатаДок
                                   ,@ВидОтгрузки
                                   ,@СтатусРейса
                                   ,@Заказчик
                                   ,@Грузоотправитель
                                   ,@ДатаНачалаПогрузкиПлан
                                   ,@ВремяНачалаПогрузкиПлан
                                   ,@ДатаНачалаПогрузкиФакт
                                   ,@ВремяНачалаПогрузкиФакт
                                   ,@ДатаОкончанияПогрузкиПлан
                                   ,@ВремяОкончанияПогрузкиПлан
                                   ,@ДатаОкончанияПогрузкиФакт
                                   ,@ВремяОкончанияПогрузкиФакт
                                   ,@АТПСсылка
                                   ,@АТП
                                   ,@ТЭП
                                   ,@Водитель
                                   ,@ВодительСерияПаспорта
                                   ,@ВодительНомерПаспорта
                                   ,@ВодительДатаВыдачиПаспорта
                                   ,@ВодительКемВыданПаспорт
                                   ,@ВодительПрава
                                   ,@Автомобиль
                                   ,@Прицеп
                                   ,@МестоПогрузки
                                   ,@ГрузСдал
                                   ,@ТипГруза
                                   ,@ВесОбщий
                                   ,@ВидПогрузки
                                   ,@СуммаФрахтПлан
                                   ,@СуммаФрахтФакт
                                   ,@ДопТЧДокументаЗаявкаТЭП_Сумма
                                   ,@ДопТЧДокументаЗаявкаТЭП_Примечание
                                   ,@Ответственный
                                   ,@ТребАвто
                                   ,@ТелефНомВодилы
                                   ,@Примечание
                                   ,@ОбщКилоМетраж
                                   ,@ID_code_truck
                                   ,@ID_code_trailer
                                   ,@ID_code_driver
                                   ,null)";
                        using (var cmd = new SqlCommand(cmdText01, connection, sqlTrans))
                        {
                            var Идентификатор = cmd.Parameters.Add("@Идентификатор", SqlDbType.NVarChar, 50);
                            var ДатаДок = cmd.Parameters.Add("@ДатаДок", SqlDbType.DateTime);
                            var ВидОтгрузки = cmd.Parameters.Add("@ВидОтгрузки", SqlDbType.Char, 9);
                            var СтатусРейса = cmd.Parameters.Add("@СтатусРейса", SqlDbType.NVarChar, 50);
                            var Заказчик = cmd.Parameters.Add("@Заказчик", SqlDbType.Char, 9);
                            var Грузоотправитель = cmd.Parameters.Add("@Грузоотправитель", SqlDbType.Char, 9);
                            var ДатаНачалаПогрузкиПлан = cmd.Parameters.Add("@ДатаНачалаПогрузкиПлан", SqlDbType.DateTime);
                            var ВремяНачалаПогрузкиПлан = cmd.Parameters.Add("@ВремяНачалаПогрузкиПлан", SqlDbType.Int);
                            var ДатаНачалаПогрузкиФакт = cmd.Parameters.Add("@ДатаНачалаПогрузкиФакт", SqlDbType.DateTime);
                            var ВремяНачалаПогрузкиФакт = cmd.Parameters.Add("@ВремяНачалаПогрузкиФакт", SqlDbType.Int);
                            var ДатаОкончанияПогрузкиПлан = cmd.Parameters.Add("@ДатаОкончанияПогрузкиПлан", SqlDbType.DateTime);
                            var ВремяОкончанияПогрузкиПлан = cmd.Parameters.Add("@ВремяОкончанияПогрузкиПлан", SqlDbType.Int);
                            var ДатаОкончанияПогрузкиФакт = cmd.Parameters.Add("@ДатаОкончанияПогрузкиФакт", SqlDbType.DateTime);
                            var ВремяОкончанияПогрузкиФакт = cmd.Parameters.Add("@ВремяОкончанияПогрузкиФакт", SqlDbType.Int);
                            var АТПСсылка = cmd.Parameters.Add("@АТПСсылка", SqlDbType.Char, 9);
                            var АТП = cmd.Parameters.Add("@АТП", SqlDbType.NVarChar, 500);
                            var ТЭП = cmd.Parameters.Add("@ТЭП", SqlDbType.Char, 9);
                            var Водитель = cmd.Parameters.Add("@Водитель", SqlDbType.NVarChar, 50);
                            var ВодительСерияПаспорта = cmd.Parameters.Add("@ВодительСерияПаспорта", SqlDbType.NVarChar, 50);
                            var ВодительНомерПаспорта = cmd.Parameters.Add("@ВодительНомерПаспорта", SqlDbType.NVarChar, 50);
                            var ВодительДатаВыдачиПаспорта = cmd.Parameters.Add("@ВодительДатаВыдачиПаспорта", SqlDbType.DateTime);
                            var ВодительКемВыданПаспорт = cmd.Parameters.Add("@ВодительКемВыданПаспорт", SqlDbType.NVarChar, 500);
                            var ВодительПрава = cmd.Parameters.Add("@ВодительПрава", SqlDbType.NVarChar, 50);
                            var Автомобиль = cmd.Parameters.Add("@Автомобиль", SqlDbType.NVarChar, 50);
                            var Прицеп = cmd.Parameters.Add("@Прицеп", SqlDbType.NVarChar, 50);
                            var МестоПогрузки = cmd.Parameters.Add("@МестоПогрузки", SqlDbType.NVarChar, 80);
                            var ГрузСдал = cmd.Parameters.Add("@ГрузСдал", SqlDbType.Char, 9);
                            var ТипГруза = cmd.Parameters.Add("@ТипГруза", SqlDbType.NVarChar, 50);
                            var ВесОбщий = cmd.Parameters.Add("@ВесОбщий", SqlDbType.NVarChar, 50);
                            var ВидПогрузки = cmd.Parameters.Add("@ВидПогрузки", SqlDbType.NVarChar, 50);
                            var СуммаФрахтПлан = cmd.Parameters.Add("@СуммаФрахтПлан", SqlDbType.Money);
                            var СуммаФрахтФакт = cmd.Parameters.Add("@СуммаФрахтФакт", SqlDbType.Money);
                            var ДопТЧДокументаЗаявкаТЭП_Сумма = cmd.Parameters.Add("@ДопТЧДокументаЗаявкаТЭП_Сумма", SqlDbType.Money);
                            var ДопТЧДокументаЗаявкаТЭП_Примечание = cmd.Parameters.Add("@ДопТЧДокументаЗаявкаТЭП_Примечание", SqlDbType.NVarChar, 50);
                            var Ответственный = cmd.Parameters.Add("@Ответственный", SqlDbType.Char, 9);
                            var ТребАвто = cmd.Parameters.Add("@ТребАвто", SqlDbType.NVarChar, 100);
                            var ТелефНомВодилы = cmd.Parameters.Add("@ТелефНомВодилы", SqlDbType.NVarChar, 50);
                            var Примечание = cmd.Parameters.Add("@Примечание", SqlDbType.NVarChar, 100);
                            var ОбщКилоМетраж = cmd.Parameters.Add("@ОбщКилоМетраж", SqlDbType.Int);
                            var ID_code_truck = cmd.Parameters.Add("@ID_code_truck", SqlDbType.NVarChar, 50);
                            var ID_code_trailer = cmd.Parameters.Add("@ID_code_trailer", SqlDbType.NVarChar, 50);
                            var ID_code_driver = cmd.Parameters.Add("@ID_code_driver", SqlDbType.NVarChar, 50);

                            Идентификатор.Value = header.IdTrip;
                            ДатаДок.Value = header.DateDoc;
                            ВидОтгрузки.Value = header.LoadForm;
                            СтатусРейса.Value = header.TripStatus;
                            Заказчик.Value = header.Customer;
                            Грузоотправитель.Value = header.Shipper;
                            ДатаНачалаПогрузкиПлан.Value = header.DateStartLoadingPlan;
                            ВремяНачалаПогрузкиПлан.Value = header.TimeSecStartLoadingPlan;
                            ДатаНачалаПогрузкиФакт.Value = header.DateStartLoadingRealise;
                            ВремяНачалаПогрузкиФакт.Value = header.TimeSecStartLoadingRealise;
                            ДатаОкончанияПогрузкиПлан.Value = header.DateFinishLoadingPlan;
                            ВремяОкончанияПогрузкиПлан.Value = header.TimeSecFinishLoadingPlan;
                            ДатаОкончанияПогрузкиФакт.Value = header.DateFinishLoadingRealise;
                            ВремяОкончанияПогрузкиФакт.Value = header.TimeSecFinishLoadingRealise;
                            АТПСсылка.Value = header.CarrierAutoId;
                            АТП.Value = header
                                .CarrierAutoName;
                            ТЭП.Value = header.CarrierShopId;
                            Водитель.Value = header.DriversName;
                            ВодительСерияПаспорта.Value = header.DriversPassportSeries;
                            ВодительНомерПаспорта.Value = header.DriversPassportNumber;
                            ВодительДатаВыдачиПаспорта.Value = header.DriversPassportDateIssued;
                            ВодительКемВыданПаспорт.Value = header.DriversPassportIssuedBy;
                            ВодительПрава.Value = header.DriversLicense;
                            Автомобиль.Value = header.TruckName;
                            Прицеп.Value = header.TrailerName;
                            МестоПогрузки.Value = header.LoadingPlaceCode;
                            ГрузСдал.Value = header.StufferId;
                            ТипГруза.Value = header.LoadType;
                            ВесОбщий.Value = header.Weight;
                            ВидПогрузки.Value = header.LoadingType;
                            СуммаФрахтПлан.Value = header.SummCostPlan;
                            СуммаФрахтФакт.Value = header.SummCostRealise;
                            ДопТЧДокументаЗаявкаТЭП_Сумма.Value = header.SummSurcharge;
                            ДопТЧДокументаЗаявкаТЭП_Примечание.Value = header.SurchargeComment;
                            Ответственный.Value = header.CreatedStufferId;
                            ТребАвто.Value = header.TruckLength;
                            ТелефНомВодилы.Value = header.DriversPhoneNumber;
                            Примечание.Value = header.Comment;
                            ОбщКилоМетраж.Value = header.Distance;
                            ID_code_truck.Value = header.IdCodeTruck;
                            ID_code_trailer.Value = header.IdCodeTrailer;
                            ID_code_driver.Value = header.IdCodeDriver;

                            cmd.ExecuteNonQuery();

                            sqlTrans.Commit();
                        }
                    }
                    var cmdText02 = @"select max(Код) from dbo._1s_TMS_Import_ЗаявкаТЭП_ш;";
                    using (var cmd = new SqlCommand(cmdText02, connection))
                    {
                        result = (System.Int64)cmd.ExecuteScalar();
                    }

                    connection.Close();
                }
            }
            catch
            {
                result = -1;
            }
            return result;
        }

        public static void Lines(System.Int64 gatewayId, TripLines lines)
        {
            foreach (var order in lines.Orders)
            {
                //try
                //{
                    SqlConnection connection = new SqlConnection("context connection=true");
                    using (connection)
                    {
                        connection.Open();
                        using (var sqlTrans = connection.BeginTransaction())
                        {
                            var cmdText = @"INSERT INTO [dbo].[_1s_TMS_Import_ЗаявкаТЭП_т]
                                           ([КодШапки]
                                           ,[ДокументРасхода]
                                           ,[ДатаПрибытия]
                                           ,[ВремяРасчетное]
                                           ,[ДатаПрибытияФакт]
                                           ,[ВремяФактическое]
                                           ,[ДатаУбытия]
                                           ,[ВремяУбытияСтр]
                                           ,[ДатаУбытияФакт]
                                           ,[ВремяУбытияФактСтр]
                                           ,[ВидОтгрузкиЗаявкиТЭП]
                                           ,[Порядок]
                                           ,[Км])
                                     VALUES
                                           (@КодШапки
                                           ,@ДокументРасхода
                                           ,getdate() --@ДатаПрибытия
                                           ,'14:12' --@ВремяРасчетное
                                           ,getdate() --@ДатаПрибытияФакт
                                           ,'14:12' --@ВремяФактическое
                                           ,getdate() --@ДатаУбытия
                                           ,'14:12' --@ВремяУбытияСтр
                                           ,getdate() --@ДатаУбытияФакт
                                           ,'14:12' --@ВремяУбытияФактСтр
                                           ,@ВидОтгрузкиЗаявкиТЭП
                                           ,@Порядок
                                           ,@Км)";
                            using (var cmd = new SqlCommand(cmdText, connection, sqlTrans))
                            {
                                var КодШапки = cmd.Parameters.Add("@КодШапки", SqlDbType.BigInt);
                                var ДокументРасхода = cmd.Parameters.Add("@ДокументРасхода", SqlDbType.Char, 13);
                                //var ДатаПрибытия = cmd.Parameters.Add("@ДатаПрибытия", SqlDbType.DateTime);
                                //var ВремяРасчетное = cmd.Parameters.Add("@ВремяРасчетное", SqlDbType.NVarChar, 5);
                                //var ДатаПрибытияФакт = cmd.Parameters.Add("@ДатаПрибытияФакт", SqlDbType.DateTime);
                                //var ВремяФактическое = cmd.Parameters.Add("@ВремяФактическое", SqlDbType.NVarChar, 5);
                                //var ДатаУбытия = cmd.Parameters.Add("@ДатаУбытия", SqlDbType.DateTime);
                                //var ВремяУбытияСтр = cmd.Parameters.Add("@ВремяУбытияСтр", SqlDbType.NVarChar, 5);
                                //var ДатаУбытияФакт = cmd.Parameters.Add("@ДатаУбытияФакт", SqlDbType.DateTime);
                                //var ВремяУбытияФактСтр = cmd.Parameters.Add("@ВремяУбытияФактСтр", SqlDbType.NVarChar, 5);
                                var ВидОтгрузкиЗаявкиТЭП = cmd.Parameters.Add("@ВидОтгрузкиЗаявкиТЭП", SqlDbType.Char, 9);
                                var Порядок = cmd.Parameters.Add("@Порядок", SqlDbType.Int);
                                var Км = cmd.Parameters.Add("@Км", SqlDbType.Decimal);

                                КодШапки.Value = gatewayId;
                                ДокументРасхода.Value = order.OrderId;
                                //ДатаПрибытия.Value = order.DateOfArrivalPlan;
                                //ВремяРасчетное.Value = order.TimeOfArrivalPlan;
                                //ДатаПрибытияФакт.Value = order.DateOfArrivalRealise;
                                //ВремяФактическое.Value = order.TimeOfArrivalRealise;
                                //ДатаУбытия.Value = order.DateOfDeparturePlan;
                                //ВремяУбытияСтр.Value = order.TimeOfDeparturePlan;
                                //ДатаУбытияФакт.Value = order.DateOfDepartureRealise;
                                //ВремяУбытияФактСтр.Value = order.TimeOfDepartureRealise;
                                ВидОтгрузкиЗаявкиТЭП.Value = order.LoadForm;
                                Порядок.Value = order.OrderVisitation;
                                Км.Value = order.Distance;

                                cmd.ExecuteNonQuery();

                                sqlTrans.Commit();
                            }
                            connection.Close();
                        }
                    }
                //}
                //catch
                //{
                //}
            }
        }
    }
}
