using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegate
{
    public delegate void PrintEventsHandler(object stringPrint, DateTime timePrint);

    class StringsRepository : IStringsRepository
    {
        private MyString[] _strings;
        private int _numLastItem; 

        public StringsRepository(int count)
        {
            _strings = new MyString[count];
            _numLastItem = 0;
        }

        public void Add(MyString str)
        {
            _strings[_numLastItem++] = str;
        }

        public event PrintEventsHandler PrintEvent;

        public void Print()
        {
            for (int i = 0; i < _numLastItem; i++)
            {
                Console.WriteLine($"{i}.{_strings[i].TimeInputed} - {_strings[i].TextInputed}");
                if (PrintEvent != null)
                {
                    PrintEvent.Invoke(_strings[i], DateTime.Now);
                }
            }
        }
    }
}
