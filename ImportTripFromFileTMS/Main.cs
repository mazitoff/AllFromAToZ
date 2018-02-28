using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Threading.Tasks;

namespace ImportTripFromCSVTMS
{
    public class Main
    {
        public static void Start()
        {
            IEnumerable<string> files = FileList.Files();

                foreach (var file in files)
                {

                    //IEnumerable<string> fileStrings = File.ReadAllLines(file);
                    //foreach (var line in fileStrings)
                    //{
                    //    //Console.WriteLine("================================");
                    //    //Console.WriteLine(file);
                    //    //Console.WriteLine("================================");
                    //    //break;
                    //}
                    Trip trip = new Trip();
                    trip.Test(file);

                }
        }

    }
}
