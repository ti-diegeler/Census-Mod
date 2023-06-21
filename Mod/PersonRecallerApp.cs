using Democracy.Entity;
using Democracy.GameAPI.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Democracy.Mod
{
    internal class PersonRecallerApp
    {
        public void Up()
        {
            PersonPublisher.Instance.Subscribe(Handle, PersonSubscriptionOption.Citizen);
        }

        void Handle(HashSet<Person> people)
        {
            Logging.Instance.Trace("People count: " + people.Count);
        }
    }
}
