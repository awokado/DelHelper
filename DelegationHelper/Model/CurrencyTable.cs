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
        public string number = "00000";
        public string date = "00.00.000";
        private Boolean _isActual, _isFromToday; // default value is false

        /// <summary>
        /// Returns TRUE if this is the currency table that is actual for tooday's currency conversions, 
        /// also TRUE if today is sunday and table is from latest available day = friday
        /// It is "necessary condition" if you want use this obcjet for currency conversions
        /// </summary>
        public Boolean IsActual
        {
            set {_isActual = value; }
            get {return _isActual;}
        }

        /// <summary>
        /// Returns true if currency table is from today, signalise that this is correct table 
        /// It is "sufficient condition" if you want use this obcjet for currency conversions
        /// </summary>
        public Boolean IsFromToday
        {
            set { _isFromToday = value; }
            get { return _isFromToday; }
        }
    }


}
