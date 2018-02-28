using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace IOIllustration
{
    class Program
    {
        static void Main(string[] args)
        {
            // Example1
            //WorkWithFiles.FileSaveRead();

            // Example2

            var repository = new CellphonesRepository();
            var cellphone = new Cellphone
            {
                Id = 1,
                Manufacturer = "Apple",
                Model = "X",
                Price = 3402.50
            };
            var cellphone1 = new Cellphone
            {
                Id = 2,
                Manufacturer = "Samsung",
                Model = "Galaxy S7",
                Price = 2087.33
            };
            var cellphone2 = new Cellphone
            {
                Id = 3,
                Manufacturer = "Samsung",
                Model = "Torsh 8X",
                Price = 807.15
            };
            repository.Add(cellphone);
            //repository.Add(cellphone1);
            repository.AddWithStreamWriter(cellphone1);
            repository.Add(cellphone2);
            var phones = repository.GetAll();

            repository.Print(phones);

            repository.Remove(3);
            Console.WriteLine("======== after remove ========");

            phones = repository.GetAll();

            repository.Print(phones);

            Console.ReadKey();
        }

    }
}
