using System;
using System.Collections.Generic;
using System.Text;

namespace LD37.Models
{
    class Stat
    {
        public string Name { get; set; }

        public float ActiveValue => BaselineValue + BaselineModifier + ActiveModifier;

        public float ActiveModifier { get; set; }

        public float BaselineValue { get; set; }

        public float BaselineModifier { get; set; }

        public Stat(string name)
        {
            this.Name = name;
            this.BaselineValue = 1.0f;
        }
    }
}
