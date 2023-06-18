using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Democracy.GameAPI.Impl
{
    internal class Logging : ILogging
    {

        private ILogging logger;
        private static Logging instance;

        private Logging() { 
            switch(App.gameVer)
            {
                case App.GameVer.CitiesSkylines2015:
                    logger = new GameAPI.CS1Adapter.LoggingAdapter();
                    break;
            }
        }

        public static Logging Instance { get
            {
                if (instance == null)
                {
                    instance = new Logging();
                }
                return instance;
            }
        }

        public void Trace(string message)
        {
            logger.Trace(message);
        }
    }
}
