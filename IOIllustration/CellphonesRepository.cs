using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;

namespace IOIllustration
{
    class CellphonesRepository : ICellphonesRepository
    {
        private const string PathFileRepository = @"d:\temp\IOTest\Cellphones.txt";

        public void Add(Cellphone phone)
        {
            var phoneString = JsonConvert.SerializeObject(phone);
            File.AppendAllLines(PathFileRepository, new[] { phoneString });
        }

        public void AddWithStreamWriter(Cellphone phone)
        {
            //string text = "";
            //using (StreamReader sReader = new StreamReader(PathFileRepository))
            //{
            //    text = sReader.ReadToEnd();
            //}
            //using (StreamWriter sWriter = new StreamWriter(PathFileRepository))
            //{
            //    sWriter.WriteLine(text + JsonConvert.SerializeObject(phone));
            //}
            using (StreamWriter sWriter = new StreamWriter(PathFileRepository,true))
            {
                sWriter.WriteLine(JsonConvert.SerializeObject(phone));
            }

        }

        public IEnumerable<Cellphone> GetAll()
        {
            var phonesArray = File.ReadAllLines(PathFileRepository);
            var phones = phonesArray.Select(x => JsonConvert.DeserializeObject<Cellphone>(x));
            return phones;
        }

        public void Remove(int id)
        {
            var phones = GetAll().Where(x => x.Id != id);
            File.Open(PathFileRepository, FileMode.Truncate)
                .Close();
            foreach (var phone in phones)
            {
                Add(phone);
            }
        }

        public void Print(IEnumerable<Cellphone> phones)
        {
            foreach (var phone in phones)
            {
                Console.WriteLine(phone);
            }

        }

    }
}
