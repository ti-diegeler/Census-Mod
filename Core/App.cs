using Democracy.Mod;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Democracy
{
    internal static class App
    {

        public static GameVer gameVer;

        internal enum GameVer {
            CitiesSkylines2015,
            CitiesSkylines2023
            }

        public static void Init()
        {
            new PersonRecallerApp().Up();
        }
    }
}
