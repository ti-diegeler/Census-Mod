using Democracy.GameAPI.Impl;
using ICities;

namespace Democracy.GameAPI.CS1Adapter
{
    public class UserModAdapter : IUserMod
    {

        IDescription description;

        public UserModAdapter()
        {
            this.description = new Description();
        }

        public string Name => description.Name;

        public string Description => description.Description;
    }
}
