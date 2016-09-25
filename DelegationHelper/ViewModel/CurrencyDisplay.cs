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
        private CurrencyTable todaysCurrTable = null;
        private Engine engine = null;
        public event PropertyChangedEventHandler PropertyChanged;
        public NotifyTaskCompletion<CurrencyTable> UrlByteCount { get; private set; }

        public CurrencyDisplay()
        {
            engine = Engine.getEngine();
            Initializer();
        }


        private  void Initializer()
        {
            //TodaysCurrTable = await NBPTableDownloader.getNBPCurrencyTable();
            UrlByteCount = new NotifyTaskCompletion<CurrencyTable>(NBPTableDownloader.getNBPCurrencyTable());
            TodaysCurrTable = UrlByteCount.Result;
        }


        //-----------------------------------------------------------------------------//
        public CurrencyTable TodaysCurrTable
        {
            get { return todaysCurrTable; }
            set
            {
                todaysCurrTable = value;
                onPropertyChanged("ActualCurrencyTable");
                onPropertyChanged("ActualCurrencyTableDate");
            }
        }
        public List<Currency> ActualCurrencyTable
        {
            get { return todaysCurrTable.items; }

        }
        public String ActualCurrencyTableDate
        {
            get { return todaysCurrTable.date; }
        }


        //-----------------------------------------------------------------------------//
        private void onPropertyChanged(params string[] propertyNames)
        {
            if (PropertyChanged != null)
            {
                foreach (string propertyName in propertyNames)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
                }
            }
        }
    }
}
