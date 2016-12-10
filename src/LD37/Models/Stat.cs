using System;
using System.Collections.Generic;
using System.Text;

namespace LD37.Models
{
    class Stat
    {
        public string Name { get; set; }

        public int ActiveValue => BaselineValue + BaselineModifier + ActiveModifier;

        public int ActiveModifier { get; set; }

        public int BaselineValue { get; set; }

        public int BaselineModifier { get; set; }
    }
}
