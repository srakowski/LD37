using System;
using System.Collections.Generic;
using System.Text;

namespace LD37.GameObjects
{
    public class Stat
    {
        public float Value => BaselineValue + ActiveModifier;

        public float ActiveModifier { get; set; } = 0f;

        public float BaselineValue => Baseline + BaselineModifier;

        public float BaselineModifier { get; set; } = 0f;

        public float Baseline { get; set; } = 1f;
    }
}
