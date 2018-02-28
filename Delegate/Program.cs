using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegate
{
    class Program
    {
        static void Main(string[] args)
        {
            IStringsRepository strings = new StringsRepository(100);
            for (int i = 0; i < 5; i++)
            {
                strings.Add(new MyString(Console.ReadLine(), DateTime.Now));
            }

            strings.PrintEvent += ShowPrintInfo;

            strings.Print();

            // delay
            Console.ReadKey();
        }

        private static void ShowPrintInfo(object stringPrint, DateTime timePrint)
        {
            Console.WriteLine($"-- event {stringPrint} - {timePrint}");
        }
    }
}
