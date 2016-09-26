using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegationHelper
{
    class Currency
    {
        /// <summary>
        /// Name of currency, e.g. "zloty"
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Code of the name, e.g.  "PLN"
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// Exchange rate to some other currency 
        /// </summary>
        public string ExchangeRate { get; set; }
        /// <summary>
        /// Conversion factor, e.g. 1000 for NOK
        /// </summary>
        public string Converter { get; set; }

    }
}
