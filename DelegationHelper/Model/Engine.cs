using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegationHelper.Model
{
    class Engine
    {
        private static Engine myInstance;


        public static Engine getEngine()
        {
            if(myInstance == null)
            {
                myInstance = new Engine();
            }
            return myInstance;
        }
    }
}
