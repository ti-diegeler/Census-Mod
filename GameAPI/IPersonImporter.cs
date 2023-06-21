using Democracy.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Democracy.GameAPI
{
    internal interface IPersonImporter
    {
        HashSet<Person> GetPeople(PersonGameAPIType personType);
    }
}
