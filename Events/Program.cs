using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events
{
    class Program
    {
        static void Main(string[] args)
        {
            var account = new Account(100);
            account.Added += ShowMessage;
            account.Withdrowed += ShowMessage;

            account.Put(200);
            account.Withdrow(100);
            account.Withdrow(500);

            Console.ReadKey();
        }

        static void ShowMessage(object sender, AccountEventArgs evArgs)
        {
            Console.WriteLine($"Transaction: {evArgs.Sum} dollars");
            Console.WriteLine(evArgs.Message);
        }
    }
}
