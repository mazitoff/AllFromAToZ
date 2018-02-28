using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace IOIllustration
{
    public static class WorkWithFiles
    {
        public static void FileSaveRead()
        {

            var consoleStream = Console.In;
            var consoleOut = Console.Out;
            var consoleError = Console.Error;

            var pathFile = @"d:\temp\IOTest\file_02.txt";
            var fileStream = File.Create(pathFile);
            //fileStream.Lock(0, fileStream.Length);
            //fileStream.Unlock(0, fileStream.Length);
            fileStream.Close();

            pathFile = @"d:\temp\IOTest\file.txt";
            using (fileStream = File.OpenWrite(pathFile))
            {
                //fileStream.Write("first line",0,0)
                //File.Writ

            }

            var attributes = File.GetAttributes(pathFile);

            Console.WriteLine(attributes);
            Console.WriteLine(File.GetCreationTime(pathFile));

            var text = "Hello world!!!";
            File.WriteAllLines(pathFile, new[] { text });
            var fileText = File.ReadAllText(pathFile);
            Console.WriteLine(fileText);

            //foreach (var item in attributes)
            //{
            //    Console.WriteLine(item);
            //}

            Console.ReadKey();
        }

    }
}
