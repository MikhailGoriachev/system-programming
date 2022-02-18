using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SynchronisationSystemOjects
{
    static class Utils
    {
        // полученпие случайных чисел
        private static Random _rand = new Random();
        public static int GetRandom(int Lo, int Hi) => _rand.Next(Lo, Hi + 1);
    } // class Utils
}
