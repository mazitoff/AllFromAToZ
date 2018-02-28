using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolyMorphism
{
    public enum Sex {Male, Female};
    class Human
    {
        public Human() { }
        public Human(string lName, string fName, Sex sex)
        {
            LastName = lName;
            FirstName = fName;
            Sex = sex;
        }

        public string LastName { get; set; }
        public string FirstName { get; set; }
        public Sex Sex { get; set; }

        public virtual void Print()
        {
            Console.WriteLine("Last Name: {0}, First Name: {1}, Sex: {2}", LastName, FirstName, Sex);
        }
    }
}
