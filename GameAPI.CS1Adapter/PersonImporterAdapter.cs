using ColossalFramework;
using Democracy.Entity;
using Democracy.GameAPI.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Democracy.GameAPI.CS1Adapter
{
    internal class PersonImporterAdapter : IPersonImporter
    {
        protected CitizenManager cs1CitizenManager;

        public PersonImporterAdapter()
        {
            cs1CitizenManager = CitizenManager.instance;
        }

        HashSet<Person> IPersonImporter.GetPeople(PersonType personType)
        {
            
            Citizen[] citizens = cs1CitizenManager.m_citizens.m_buffer;
            HashSet<Person> output = new HashSet<Person>();
            uint counter = 0;
            foreach(Citizen c in citizens)
            {
                counter++;
                if ((c.m_flags & Citizen.Flags.Created) == Citizen.Flags.Created)
                {
                    Person p = new Person();
                    p.id = counter; //p.id = c.m_instance; this literally cost me two hours to figure out why this is a bad choice

                    if (IsPersonType(c, personType))
                    {
                        
                        output.Add(p);
                        p.type = personType;
                    } 
                    
                }
            }
            return output;
        }

        protected bool IsPersonType(Citizen citizen, PersonType personType)
        {
            bool isCreated = citizen.m_flags.GetFlags().Contains(Citizen.Flags.Created);
            bool isDummyTraffic = citizen.m_flags.GetFlags().Contains(Citizen.Flags.DummyTraffic);
            bool isTourist = citizen.m_flags.GetFlags().Contains(Citizen.Flags.Tourist);
            bool isDead = citizen.m_flags.GetFlags().Contains(Citizen.Flags.Dead);
            bool isMovingIn = citizen.m_flags.GetFlags().Contains(Citizen.Flags.MovingIn);
            switch (personType)
            {
                case PersonType.Citizen:
                    return isCreated && !isDummyTraffic && !isTourist && !isDead && !isMovingIn;
                case PersonType.Foreigner:
                    return isCreated && !isDead && (isDummyTraffic || isTourist);
                default: 
                    return isCreated && !isDead;
            }
        }
    }
}
