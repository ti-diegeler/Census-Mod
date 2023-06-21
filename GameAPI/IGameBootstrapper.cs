namespace Democracy.GameAPI
{

    internal interface IGameBootstrapper
    {
        void Start(App.GameVer gameVersion);
        void OnLevelLoaded(bool isRelevantLevel);
        void OnLevelUnloaded();
    }
}
