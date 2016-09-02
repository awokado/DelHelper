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
        private readonly CurrencyTable curTable = NBPTableDownloader.getNBPCurrencyTable();

        public event PropertyChangedEventHandler PropertyChanged;


        public List<Currency> currencyTable
        {
            get { Console.WriteLine("--1--------------------------------------------------------------");  return curTable.items; }
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
