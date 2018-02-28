using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImportFromTMS
{
    class TripLines
    {
        public List<Order> Orders { get; set; }

        public TripLines()
        {
            Orders = new List<Order>();
        }

        public void Add(Order order)
        {
            //Console.WriteLine(order.GetType());
            Orders.Add(order);
        }
    }
}
