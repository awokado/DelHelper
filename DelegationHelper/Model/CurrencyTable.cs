using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DelegationHelper.Model;

namespace DelegationHelper
{
    class CurrencyTable
    {
        public List<Currency> items = new List<Currency>();
        public string number, date;

        public static implicit operator CurrencyTable(NotifyTaskCompletion<CurrencyTable> v)
        {
            throw new NotImplementedException();
        }
    }

}
