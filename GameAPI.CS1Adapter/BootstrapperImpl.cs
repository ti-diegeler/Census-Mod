using ICities;
using Democracy.GameAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Democracy.Core
using static ColossalFramework.IO.EncodedArray;

namespace Democracy.GameAPI.CS1Adapter
{
    internal class BootstrapperAdapter : ILoadingExtension
    {
        protected IBootstrapper boot = null;

        void ILoadingExtension.OnCreated(ILoading loading)
        {
        }

        void ILoadingExtension.OnLevelLoaded(LoadMode mode)
        {
            if(boot == null)
            {
                IBootstrapper boot = Bootstrapper.Instance;
            }
            switch (mode)
            {
                case LoadMode.NewGame:
                    boot.OnLevelLoaded(true);
                    break;
                default:
                    break;
            }
        }

        void ILoadingExtension.OnLevelUnloading()
        {
            boot.OnLevelUnloaded();
        }

        void ILoadingExtension.OnReleased()
        {
        }
    }
}
