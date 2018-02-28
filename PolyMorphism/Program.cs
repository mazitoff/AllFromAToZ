using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolyMorphism
{
    class Program
    {
        static void Main(string[] args)
        {
            Human[] people = new Human[3];
            Human jack = new Human("Morozoff", "Jack", Sex.Male);
            people[0] = jack;
            Passenger olga = new Passenger("Svetlova", "Olga", Sex.Female, "TJ930012");
            people[1] = olga;
            Human stiff = new Human("Lourens", "Stiff", Sex.Male);
            people[2] = stiff;

            for (int i = 0; i < 3; i++)
            {
                people[i].Print();
            }
            Console.ReadKey();
        }
    }
}
