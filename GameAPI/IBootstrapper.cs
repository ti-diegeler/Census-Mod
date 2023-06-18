namespace Democracy.GameAPI
{

    internal interface IBootstrapper
    {
        void Start(App.GameVer gameVersion);
        void OnLevelLoaded(bool isRelevantLevel);
        void OnLevelUnloaded();
    }
}
