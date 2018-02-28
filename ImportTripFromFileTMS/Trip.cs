using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace ImportTripFromCSVTMS
{
    class Trip
    {
        public void Test(string fileName)
        {
                string stringUnit = "";
                char symbol = new char();
                int lineNumber = 0;
                List<string> unitsFromLine = new List<string>();
                IEnumerable<string> fileStrings = File.ReadAllLines(fileName);
                TripLines tripLines = new TripLines();
                foreach (var line in fileStrings)
                {

                    lineNumber += 1;
                    if (lineNumber == 2)// || lineNumber > 3)
                    {
                        //Console.WriteLine(line);
                        for (int i = 0; i < line.Length; i++)
                        {
                            symbol = line[i];
                            //Console.WriteLine($"symbol = {symbol}, line.Length = {line.Length}, i = {i}");
                            if (symbol == ';')
                            {
                                unitsFromLine.Add(stringUnit);
                                stringUnit = "";
                            }
                            else if (i == line.Length - 1)
                            {
                                stringUnit += line[i];
                                unitsFromLine.Add(stringUnit);
                                stringUnit = "";
                            }
                            else
                            {
                                stringUnit += line[i];
                            }
                        }
                        TripHeader header = new TripHeader(unitsFromLine);
                        SaveHeader(header);
                    }
                    else if (lineNumber > 3)
                    {
                        unitsFromLine.Clear();
                        //Console.WriteLine(line.Count());
                        //Console.WriteLine(line);
                        for (int i = 0; i < line.Length; i++)
                        {
                            symbol = line[i];
                            //Console.WriteLine($"symbol = {symbol}, line.Length = {line.Length}, i = {i}");
                            if (symbol == ';')
                            {
                                //Console.WriteLine(stringUnit);
                                unitsFromLine.Add(stringUnit);
                                stringUnit = "";
                            }
                            else if (i == line.Length - 1)
                            {
                                stringUnit += line[i];
                                //Console.WriteLine(stringUnit);
                                unitsFromLine.Add(stringUnit);
                                stringUnit = "";
                            }
                            else
                            {
                                stringUnit += line[i];
                            }
                        }
                        tripLines.Add(new Order(unitsFromLine));
                    }
                }
        }
        public void SaveHeader(TripHeader header)
        {
            SqlConnection connection = new SqlConnection("context connection=true");
            using (connection)
            {
                connection.Open();
                using (var sqlTrans = connection.BeginTransaction()) //one transaction instead of many from each insert implicit
                {
                    string cmdText = @"if object_id(N'dbo.trip_header',N'U') is null
                    	create table dbo.trip_header (
trip_code                               varchar(50),
created_datetime                        varchar(50),
shift_status                            varchar(50),
transportation_client                   varchar(50),
shipper                                 varchar(50),
planned_pickup_stop_startInstant        varchar(50),
realized_pickup_stop_startInstant       varchar(50),
planned_pickup_stop_finishInstant       varchar(50),
realized_pickup_stop_finishInstant      varchar(50),
resource_subcontractor_externalId       varchar(50),
resource_subcontractor_name             varchar(50),
shift_subcontractor                     varchar(50),
driver_name                             varchar(50),
driver_passport_series                  varchar(50),
driver_passport_number                  varchar(50),
driver_passport_date_issued             varchar(50),
driver_passport_issued_by               varchar(50),
driver_driver_license                   varchar(50),
truck_name                              varchar(50),
trailer_name                            varchar(50),
pickup_address_externalId               varchar(50),
products                                varchar(50),
truck_capacity                          varchar(50),
addresses_delivery_capabilities         varchar(50),
plancost                                varchar(50),
realcost                                varchar(50),
surcharge                               varchar(50),
surcharge_comment                       varchar(50),
created_user                            varchar(50),
udf_truck_length                        varchar(50),
driver_phone                            varchar(50),
shift_comment                           varchar(50),
disable_delivery_type_check             varchar(50),
trip_distance                           varchar(50),
ID_code_truck                           varchar(50),
ID_code_trailer                         varchar(50),
ID_code_driver                          varchar(50)
)";
                    using (var cmd01 = new SqlCommand(cmdText, connection, sqlTrans))
                    {
                        cmd01.ExecuteNonQuery();
                    }

                    cmdText = @"INSERT INTO dbo.trip_header VALUES (
@v01,@v02,@v03,@v04,@v05,@v06,@v07,@v08,@v09,@v10,@v11,@v12,@v13,@v14,@v15,@v16,@v17,@v18,@v19,@v20,@v21,@v22,@v23,@v24,@v25,@v26,@v27,@v28,@v29,@v30,@v31,@v32,@v33,@v34,@v35,@v36,@v37)";
                    using (var cmd = new SqlCommand(cmdText, connection, sqlTrans))
                    {
                        var v01 = cmd.Parameters.Add("@v01", SqlDbType.NVarChar, 50);
                        var v02 = cmd.Parameters.Add("@v02", SqlDbType.NVarChar, 50);
                        var v03 = cmd.Parameters.Add("@v03", SqlDbType.NVarChar, 50);
                        var v04 = cmd.Parameters.Add("@v04", SqlDbType.NVarChar, 50);
                        var v05 = cmd.Parameters.Add("@v05", SqlDbType.NVarChar, 50);
                        var v06 = cmd.Parameters.Add("@v06", SqlDbType.NVarChar, 50);
                        var v07 = cmd.Parameters.Add("@v07", SqlDbType.NVarChar, 50);
                        var v08 = cmd.Parameters.Add("@v08", SqlDbType.NVarChar, 50);
                        var v09 = cmd.Parameters.Add("@v09", SqlDbType.NVarChar, 50);
                        var v10 = cmd.Parameters.Add("@v10", SqlDbType.NVarChar, 50);
                        var v11 = cmd.Parameters.Add("@v11", SqlDbType.NVarChar, 50);
                        var v12 = cmd.Parameters.Add("@v12", SqlDbType.NVarChar, 50);
                        var v13 = cmd.Parameters.Add("@v13", SqlDbType.NVarChar, 50);
                        var v14 = cmd.Parameters.Add("@v14", SqlDbType.NVarChar, 50);
                        var v15 = cmd.Parameters.Add("@v15", SqlDbType.NVarChar, 50);
                        var v16 = cmd.Parameters.Add("@v16", SqlDbType.NVarChar, 50);
                        var v17 = cmd.Parameters.Add("@v17", SqlDbType.NVarChar, 50);
                        var v18 = cmd.Parameters.Add("@v18", SqlDbType.NVarChar, 50);
                        var v19 = cmd.Parameters.Add("@v19", SqlDbType.NVarChar, 50);
                        var v20 = cmd.Parameters.Add("@v20", SqlDbType.NVarChar, 50);
                        var v21 = cmd.Parameters.Add("@v21", SqlDbType.NVarChar, 50);
                        var v22 = cmd.Parameters.Add("@v22", SqlDbType.NVarChar, 50);
                        var v23 = cmd.Parameters.Add("@v23", SqlDbType.NVarChar, 50);
                        var v24 = cmd.Parameters.Add("@v24", SqlDbType.NVarChar, 50);
                        var v25 = cmd.Parameters.Add("@v25", SqlDbType.NVarChar, 50);
                        var v26 = cmd.Parameters.Add("@v26", SqlDbType.NVarChar, 50);
                        var v27 = cmd.Parameters.Add("@v27", SqlDbType.NVarChar, 50);
                        var v28 = cmd.Parameters.Add("@v28", SqlDbType.NVarChar, 50);
                        var v29 = cmd.Parameters.Add("@v29", SqlDbType.NVarChar, 50);
                        var v30 = cmd.Parameters.Add("@v30", SqlDbType.NVarChar, 50);
                        var v31 = cmd.Parameters.Add("@v31", SqlDbType.NVarChar, 50);
                        var v32 = cmd.Parameters.Add("@v32", SqlDbType.NVarChar, 50);
                        var v33 = cmd.Parameters.Add("@v33", SqlDbType.NVarChar, 50);
                        var v34 = cmd.Parameters.Add("@v34", SqlDbType.NVarChar, 50);
                        var v35 = cmd.Parameters.Add("@v35", SqlDbType.NVarChar, 50);
                        var v36 = cmd.Parameters.Add("@v36", SqlDbType.NVarChar, 50);
                        var v37 = cmd.Parameters.Add("@v37", SqlDbType.NVarChar, 50);

                        v01.Value = header.trip_code;
                        v02.Value = header.created_datetime;
                        v03.Value = header.shift_status;
                        v04.Value = header.transportation_client;
                        v05.Value = header.shipper;
                        v06.Value = header.planned_pickup_stop_startInstant;
                        v07.Value = header.realized_pickup_stop_startInstant;
                        v08.Value = header.planned_pickup_stop_finishInstant;
                        v09.Value = header.realized_pickup_stop_finishInstant;
                        v10.Value = header.resource_subcontractor_externalId;
                        v11.Value = header.resource_subcontractor_name;
                        v12.Value = header.shift_subcontractor;
                        v13.Value = header.driver_name;
                        v14.Value = header.driver_passport_series;
                        v15.Value = header.driver_passport_number;
                        v16.Value = header.driver_passport_date_issued;
                        v17.Value = header.driver_passport_issued_by;
                        v18.Value = header.driver_driver_license;
                        v19.Value = header.truck_name;
                        v20.Value = header.trailer_name;
                        v21.Value = header.pickup_address_externalId;
                        v22.Value = header.products;
                        v23.Value = header.truck_capacity;
                        v24.Value = header.addresses_delivery_capabilities;
                        v25.Value = header.plancost;
                        v26.Value = header.realcost;
                        v27.Value = header.surcharge;
                        v28.Value = header.surcharge_comment;
                        v29.Value = header.created_user;
                        v30.Value = header.udf_truck_length;
                        v31.Value = header.driver_phone;
                        v32.Value = header.shift_comment;
                        v33.Value = header.disable_delivery_type_check;
                        v34.Value = header.trip_distance;
                        v35.Value = header.ID_code_truck;
                        v36.Value = header.ID_code_trailer;
                        v37.Value = header.ID_code_driver;

                        cmd.ExecuteNonQuery();
                    }
                    sqlTrans.Commit();
                }
                connection.Close();
            }

        }
    }
}
