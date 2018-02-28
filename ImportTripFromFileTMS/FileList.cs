using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ImportTripFromCSVTMS
{
    static class FileList
    {
        const string _pathToDirectory = @"d:\temp\IOTest\";

        public static IEnumerable<string> Files()
        {
            var files = Directory.GetFiles(_pathToDirectory, "*.csv", 0);
            return files;
        }
    }
}
