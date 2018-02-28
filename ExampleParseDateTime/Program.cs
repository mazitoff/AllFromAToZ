using System;
using System.Globalization;

namespace ExampleParseDateTime
{
    class Program
    {
        static void Main(string[] args)
        {
            string parDT = "2018-02-05T18:38:02+02:00";
            DateTime dT = DateTime.Parse(parDT);
            Console.WriteLine(dT);
            Console.WriteLine(dT.Date);
            TimeSpan span = dT - dT.Date;
            Console.WriteLine(span.Seconds);
            Console.WriteLine(span.Minutes);
            Console.WriteLine(span.Hours);
            Console.WriteLine(span.TotalSeconds);

            Console.WriteLine("---------------------------");
            /*
            at System.Number.StringToNumber(String str, NumberStyles options, NumberBuffer & number, NumberFormatInfo info, Boolean parseDecimal)
   at System.Number.ParseDecimal(String value, NumberStyles options, NumberFormatInfo numfmt)
   at System.Decimal.Parse(String s)
   at ImportTripFromCSVTMS.TripHeader.GetDecimalValue(String tmsCostStr)
   at ImportTripFromCSVTMS.TripHeader..ctor(IEnumerable`1 stringFromFile)
   at ImportTripFromCSVTMS.Trip..ctor(String fileName)
   at ImportTripFromCSVTMS.Import.Start()
.           */

            string str = " 45.7465688 ";
            decimal dec = GetDecimalValue(str);
            Console.WriteLine(dec);

            // delay
            Console.ReadLine();
        }

        private static decimal GetDecimalValue(string tmsCostStr)
        {
            decimal result;
            if (tmsCostStr.Trim() == "")
            {
                result = 0;
            }
            else
            {
                result = Decimal.Parse(tmsCostStr, NumberStyles.Any,  CultureInfo.InvariantCulture);
            }
            return result;
        }
    }
}
