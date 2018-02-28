using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImportFromTMS
{
    class Program
    {
        static void Main(string[] args)
        {
            IEnumerable<string> files = FileList.Files();
            foreach (var file in files)
            {
                Console.WriteLine("================================");
                Console.WriteLine(file);
                Console.WriteLine("================================");
                Trip trip = new Trip();
                trip.Test(file);
                //break;
            }

            //-- delay
            Console.ReadKey();
        }
    }
}
