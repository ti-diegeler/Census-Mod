
using ColossalFramework;
using Democracy.GameAPI;
using UnityEngine;
using static RenderManager;

namespace Democracy.GameAPI.Impl
{
    internal class Bootstrapper : IBootstrapper
    {
        protected static Bootstrapper instance;

        void IBootstrapper.Start(App.GameVer gameVersion)
        {
            App.gameVer = gameVersion;
        }

        private Bootstrapper() { }
        public static Bootstrapper Instance {
            get
            {
                if (instance == null)
                {
                    instance = new Bootstrapper();
                }
                return instance;
            }
        }

        void IBootstrapper.OnLevelLoaded(bool isRelevantLevel)
        {
            if (isRelevantLevel)
            {
                // do something
            } else
            {
                // shutdown
            }
        }

        void IBootstrapper.OnLevelUnloaded() { }


    }
}
