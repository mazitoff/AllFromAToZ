using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegate
{
    class MyString
    {
        public string TextInputed { get; set; }
        public DateTime TimeInputed { get; set; }

        public MyString(string text, DateTime time)
        {
            TextInputed = text;
            TimeInputed = time;
        }
    }
}
