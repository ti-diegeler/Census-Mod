using Democracy.Entity;
using Democracy.GameAPI.CS1Adapter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Democracy.GameAPI.Impl
{
    internal class PersonPublisher : Publisher<Person, PersonSubscriptionOption>
    {
        protected static PersonPublisher instance;
        protected IPersonImporter gameImporter;

        private PersonPublisher() 
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
            Update(gameImporter.GetPeople(PersonGameAPIType.Citizen), PersonSubscriptionOption.Citizen);
        }

        public static PersonPublisher Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new PersonPublisher();
                }
                return instance;
            }

                
        }
    }
}
