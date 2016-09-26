using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegationHelper.Model
{
    class ModelMaster
    {
        private static ModelMaster myInstance;
        private CurrencyTable latestNBPCurrTabelA = null;

        /// <summary>
        /// This class is singletone
        /// </summary>
        public static ModelMaster GetInstance
        {
            get
            {
                if (myInstance == null)
                {
                    myInstance = new ModelMaster();
                }
                return myInstance;
            }
        }


        private ModelMaster()
        {
            latestNBPCurrTabelA = getDummyCurrencyTable(); // creates dummy currency table which will be later on filled by async function
        }

        private CurrencyTable getDummyCurrencyTable()
        {
            var dummy = new CurrencyTable();
            dummy.date = "00.00.0000";
            dummy.number = "00";
            return dummy;
        }

        /// <summary>
        /// latest available (downloaded/loaded) currency table 
        /// </summary>
        public CurrencyTable LatestNBPCurrTabelA
        {
            get { return latestNBPCurrTabelA; }
        }



    }
}
