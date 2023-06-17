using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Democracy.GameAPI
{

    internal interface IBootstrapper
    {
        void OnLevelLoaded(Boolean isRelevantLevel);
        void OnLevelUnloaded();
    }
}
