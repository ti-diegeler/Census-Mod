using Democracy.GameAPI.CS1Adapter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Democracy.GameAPI.Impl
{
    internal class PersonHandler
    {
        protected static PersonHandler instance;
        protected IPersonImporter gameImporter;

        private PersonHandler() 
        {
            gameImporter = setupGameImporter();
        }

        private IPersonImporter setupGameImporter()
        {
            switch (App.gameVer)
            {
                case App.GameVer.CitiesSkylines2015:
                    return new PersonImporterAdapter();
                default:
                    throw new NotSupportedException("Support for this program not implemented");
            }
        }

        public void handle()
        {
            Logging.Instance.Trace("People count: " + gameImporter.GetPeople(Entity.PersonType.Citizen).Count);
        }

        public static PersonHandler Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new PersonHandler();
                }
                return instance;
            }

                
        }
    }
}
