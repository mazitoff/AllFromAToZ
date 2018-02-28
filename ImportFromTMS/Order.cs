using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImportFromTMS
{
    class Order
    {
        public string order_externalId { get; set; }
        public string delivery_type { get; set; }
        public string planned_delivery_stop_startInstant { get; set; }
        public string planned_delivery_stop_finishInstant { get; set; }
        public string realized_delivery_stop_startInstant { get; set; }
        public string realized_delivery_stop_finishInstant { get; set; }
        public string stopNumber { get; set; }
        public string KM_depot { get; set; }

        public Order(IEnumerable<string> stringFromFile)
        {
            if (stringFromFile.Count() == 8)
            {
                int count = 0;
                foreach (var unit in stringFromFile)
                {
                    switch (count++)
                    {
                        case 0: order_externalId = unit; break;
                        case 1: delivery_type = unit; break;
                        case 2: planned_delivery_stop_startInstant = unit; break;
                        case 3: planned_delivery_stop_finishInstant = unit; break;
                        case 4: realized_delivery_stop_startInstant = unit; break;
                        case 5: realized_delivery_stop_finishInstant = unit; break;
                        case 6: stopNumber = unit; break;
                        case 7: KM_depot = unit; break;
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
