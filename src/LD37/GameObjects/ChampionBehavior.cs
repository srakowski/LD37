using Coldsteel.Scripting;
using System;
using System.Collections.Generic;
using System.Text;

namespace LD37.GameObjects
{
    abstract class ChampionBehavior : Behavior
    {
        public Champion Champion => GameObject as Champion;
    }
}
