using DelegationHelper.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegationHelper.ViewModel
{
    class CurrencyDisplay : INotifyPropertyChanged
    {
        private readonly CurrencyTable todaysCurrTable = NBPTableDownloader.getNBPCurrencyTable();

        public event PropertyChangedEventHandler PropertyChanged;


        public List<Currency> todaysCurrencyTable
        {
            get { Console.WriteLine("--1--------------------------------------------------------------");  return todaysCurrTable.items; }
        }

        /// <summary>
        /// Returns date of downloaded currency table
        /// </summary>
        public String todaysCurrencyTableDate
        {
            get { return todaysCurrTable.date; }
        }

        private void onPropertyChanged(params string[] propertyNames)
        {
            if(PropertyChanged != null)
            {
                foreach(string propertyName in propertyNames)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
                }
            }
        }
    }
}
