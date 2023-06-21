using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Democracy.Entity
{
    [Flags]
    internal enum PersonSubscriptionOption
    {
        None = 0,
        Citizen = 1,
        PartyMember = 2
    }
}
