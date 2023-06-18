using Democracy.GameAPI.Impl;
using ICities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;

namespace Democracy.GameAPI.CS1Adapter
{
    public class ThreadingAdapter : ThreadingExtensionBase
    {
        protected uint count;
        protected float realTimeDeltaAcc;
        protected IThreadHandler threadHandler;

        public override void OnCreated(IThreading threading)
        {
            base.OnCreated(threading);
            Logging.Instance.Trace("Threading component started.");
            if (threadHandler == null)
            {
                threadHandler = ThreadHandler.Instance;
            }
        }

        public override void OnUpdate(float realTimeDelta, float simulationTimeDelta)
        {
            count++;
            realTimeDeltaAcc += realTimeDelta;
            if (count >= 60)
            {
                Logging.Instance.Trace("" + realTimeDeltaAcc);
                realTimeDeltaAcc = 0;
                count = 0;
                threadHandler.OnRelevantTick();
            }
            
        }
    }
}
