
using ColossalFramework;
using Democracy.GameAPI;
using UnityEngine;
using static RenderManager;

namespace Democracy.GameAPI.Impl
{
    internal class GameBootstrapper : IGameBootstrapper
    {
        protected static GameBootstrapper instance;

        void IGameBootstrapper.Start(App.GameVer gameVersion)
        {
            App.gameVer = gameVersion;
            App.Init();
        }

        private GameBootstrapper() { }
        public static GameBootstrapper Instance {
            get
            {
                if (instance == null)
                {
                    instance = new GameBootstrapper();
                }
                return instance;
            }
        }

        void IGameBootstrapper.OnLevelLoaded(bool isRelevantLevel)
        {
            if (isRelevantLevel)
            {
                // do something
            } else
            {
                // shutdown
            }
        }

        void IGameBootstrapper.OnLevelUnloaded() { }


    }
}
