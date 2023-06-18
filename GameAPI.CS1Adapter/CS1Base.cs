using Democracy.GameAPI.Impl;
using ICities;
using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Democracy.GameAPI.CS1Adapter
{
    internal class CS1Base
    {
        [CanBeNull]
        protected IManagers managers;

        private static CS1Base instance;

        private CS1Base() { }

        public static CS1Base Instance
        {
            get
            {
                if(instance == null)
                {
                    instance = new CS1Base();
                }
                return instance;
            }
        }

        public IManagers Managers { 
            get { 
                return managers; 
            }
            set
            {
                if (managers == null) {
                    managers = value;
                    Logging.Instance.Trace("IManagers instance saved in mod.");
                }
            }
        }

    }
}
