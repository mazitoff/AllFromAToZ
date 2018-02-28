using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolyMorphism
{
    class Passenger : Human
    {
        public Passenger() { }
        public Passenger(string lName, string fName, Sex sex, string passport) 
            : base(lName, fName, sex)
        {
            Passport = passport;
        }

        public string Passport { get; set; }

        public override void Print()
        {
            base.Print();
            Console.WriteLine("   Passport: {0}", Passport);
        }
    }
}
