using System;
using System.Collections.Generic;
using System.Text;

namespace LD37.GameObjects
{
    static class Progression
    {
        public static int WaveLevel { get; set; } = 1;


        public static void Reset()
        {
            WaveLevel = 1;
        }

    }
}
