using Coldsteel.Rendering;
using Coldsteel.Scripting;
using System;
using System.Collections.Generic;
using System.Text;

namespace LD37.GameObjects
{
    class ProgressionBehavior : Behavior
    {
        private TextRenderer _tr;

        public ProgressionBehavior(TextRenderer tr)
        {
            _tr = tr;
        }

        public override void Update()
        {
            _tr.Text = $"Level {Progression.WaveLevel}";
        }
    }
}
