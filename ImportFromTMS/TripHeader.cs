using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImportFromTMS
{
    class TripHeader
    {
        public string trip_code { get; set; }
        public string created_datetime { get; set; }
        public string shift_status { get; set; }
        public string transportation_client { get; set; }
        public string shipper { get; set; }
        public string planned_pickup_stop_startInstant { get; set; }
        public string realized_pickup_stop_startInstant { get; set; }
        public string planned_pickup_stop_finishInstant { get; set; }
        public string realized_pickup_stop_finishInstant { get; set; }
        public string resource_subcontractor_externalId { get; set; }
        public string resource_subcontractor_name { get; set; }
        public string shift_subcontractor { get; set; }
        public string driver_name { get; set; }
        public string driver_passport_series { get; set; }
        public string driver_passport_number { get; set; }
        public string driver_passport_date_issued { get; set; }
        public string driver_passport_issued_by { get; set; }
        public string driver_driver_license { get; set; }
        public string truck_name { get; set; }
        public string trailer_name { get; set; }
        public string pickup_address_externalId { get; set; }
        public string products { get; set; }
        public string truck_capacity { get; set; }
        public string addresses_delivery_capabilities { get; set; }
        public string plancost { get; set; }
        public string realcost { get; set; }
        public string surcharge { get; set; }
        public string surcharge_comment { get; set; }
        public string created_user { get; set; }
        public string udf_truck_length { get; set; }
        public string driver_phone { get; set; }
        public string shift_comment { get; set; }
        public string disable_delivery_type_check { get; set; }
        public string trip_distance { get; set; }
        public string ID_code_truck { get; set; }
        public string ID_code_trailer { get; set; }
        public string ID_code_driver { get; set; }

        public TripHeader(IEnumerable<string> stringFromFile)
        {
            if(stringFromFile.Count() == 37)
            {
                int count = 0;
                foreach (var unit in stringFromFile)
                {
                    switch (count++)
                    {
                        case 0: trip_code = unit; break;
                        case 1: created_datetime = unit; break;
                        case 2: shift_status = unit; break;
                        case 3: transportation_client = unit; break;
                        case 4: shipper = unit; break;
                        case 5: planned_pickup_stop_startInstant = unit; break;
                        case 6: realized_pickup_stop_startInstant = unit; break;
                        case 7: planned_pickup_stop_finishInstant = unit; break;
                        case 8: realized_pickup_stop_finishInstant = unit; break;
                        case 9: resource_subcontractor_externalId = unit; break;
                        case 10: resource_subcontractor_name = unit; break;
                        case 11: shift_subcontractor = unit; break;
                        case 12: driver_name = unit; break;
                        case 13: driver_passport_series = unit; break;
                        case 14: driver_passport_number = unit; break;
                        case 15: driver_passport_date_issued = unit; break;
                        case 16: driver_passport_issued_by = unit; break;
                        case 17: driver_driver_license = unit; break;
                        case 18: truck_name = unit; break;
                        case 19: trailer_name = unit; break;
                        case 20: pickup_address_externalId = unit; break;
                        case 21: products = unit; break;
                        case 22: truck_capacity = unit; break;
                        case 23: addresses_delivery_capabilities = unit; break;
                        case 24: plancost = unit; break;
                        case 25: realcost = unit; break;
                        case 26: surcharge = unit; break;
                        case 27: surcharge_comment = unit; break;
                        case 28: created_user = unit; break;
                        case 29: udf_truck_length = unit; break;
                        case 30: driver_phone = unit; break;
                        case 31: shift_comment = unit; break;
                        case 32: disable_delivery_type_check = unit; break;
                        case 33: trip_distance = unit; break;
                        case 34: ID_code_truck = unit; break;
                        case 35: ID_code_trailer = unit; break;
                        case 36: ID_code_driver = unit; break;
                    }

                }
            }
            else
            {
                //throw Exception();
            }
        }
    }
}
