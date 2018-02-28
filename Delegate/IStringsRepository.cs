using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegate
{
    interface IStringsRepository
    {
        //MyString[] _strings;
        //private int _numLastItem;

        event PrintEventsHandler PrintEvent;

        void Add(MyString str);

        void Print();
    }
}
