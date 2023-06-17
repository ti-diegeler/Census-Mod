
using Democracy.GameAPI;

namespace Democracy.Core
{
    internal class Bootstrapper : IBootstrapper
    {
        private Bootstrapper() { }
        public static Bootstrapper Instance { get; }

        void IBootstrapper.OnLevelLoaded(bool isRelevantLevel)
        {
            if(isRelevantLevel)
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
