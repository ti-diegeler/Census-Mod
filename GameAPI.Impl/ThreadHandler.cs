using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Democracy.GameAPI.Impl
{
    internal class ThreadHandler : IThreadHandler
    {
        private ThreadHandler() { }

        protected static ThreadHandler instance;

        public static ThreadHandler Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ThreadHandler();
                }
                return instance;
            }
        }

        void IThreadHandler.OnRelevantTick()
        {
            PersonHandler.Instance.handle();
        }
    }
}
