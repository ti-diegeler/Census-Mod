using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Democracy.GameAPI.CS1Adapter
{
    internal class LoggingAdapter : ILogging
    {
        void ILogging.Trace(string message)
        {
            UnityEngine.Debug.Log(message);
        }
    }
}
