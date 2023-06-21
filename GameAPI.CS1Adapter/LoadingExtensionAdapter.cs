using ICities;
using Democracy.GameAPI.Impl;

namespace Democracy.GameAPI.CS1Adapter
{
    public class LoadingExtensionAdapter : ILoadingExtension
    {
        IGameBootstrapper boot = null;

        void ILoadingExtension.OnCreated(ILoading loading)
        {
            CS1Base.Instance.Managers = loading.managers;
        }

        void ILoadingExtension.OnLevelLoaded(LoadMode mode)
        {
            if (boot == null)
            {
                boot = GameBootstrapper.Instance;
            }
            boot.Start(App.GameVer.CitiesSkylines2015);
            switch (mode)
            {
                case LoadMode.NewGame:
                    Logging.Instance.Trace("Loading Bootstrapper for new level...");
                    boot.OnLevelLoaded(true);
                    break;
                default:
                    break;
            }
        }

        void ILoadingExtension.OnLevelUnloading()

        {
            if (boot == null)
            {
                boot = GameBootstrapper.Instance;
            }
            boot.OnLevelUnloaded();
        }

        void ILoadingExtension.OnReleased()
        {
        }
    }
}
