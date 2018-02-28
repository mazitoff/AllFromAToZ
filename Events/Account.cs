using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events
{
    class Account
    {
        public event EventHandler<AccountEventArgs> Withdrowed;
        public event EventHandler<AccountEventArgs> Added;

        private double _sum;

        public double CurrentSum => _sum;

        public Account(double sum)
        {
            _sum = sum;
        } 

        public void Put(double sum)
        {
            _sum += sum;
            Added?.Invoke(this, new AccountEventArgs($"On your account added {sum} dollars", sum));
        }

        public void Withdrow(double sum)
        {
            if (sum <= _sum)
            {
                _sum -= sum;
                Withdrowed?.Invoke(this, new AccountEventArgs($"From you account spent {sum} dollars", sum));
            }
            else
            {
                Withdrowed?.Invoke(this, new AccountEventArgs($"You haven't reqested {sum - _sum} dollars", sum));
            }
        }
    }
}
