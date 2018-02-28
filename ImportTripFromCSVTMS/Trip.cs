using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ImportTripFromCSVTMS
{

    class Trip
    {
        public TripHeader Header { get; private set; }
        public TripLines Lines { get; private set; }

        public Trip(string fileName)
        {
            string stringUnit = "";
            int lineNumber = 0;
            List<string> unitsFromLine = new List<string>();
            Lines = new TripLines();

            IEnumerable<string> fileStrings = File.ReadAllLines(fileName);
            foreach (var line in fileStrings)
            {
                lineNumber += 1;
                if (lineNumber == 2 || lineNumber > 3)
                {
                    for (int i = 0; i < line.Length; i++)
                    {
                        char symbol = line[i];
                        if (symbol == ';')
                        {
                            unitsFromLine.Add(stringUnit);
                            stringUnit = "";
                        }
                        else if (i == line.Length - 1)
                        {
                            stringUnit += line[i];
                            unitsFromLine.Add(stringUnit);
                            stringUnit = "";
                        }
                        else
                        {
                            stringUnit += line[i];
                        }
                    }
                    if (lineNumber == 2)
                    {
                        Header = new TripHeader(unitsFromLine);
                        unitsFromLine.Clear();
                    }
                    else
                    {
                        Lines.Add(new Order(unitsFromLine));
                    }
                }
            }
        }
    }
}
