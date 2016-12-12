using Coldsteel.Scripting;
using System;
using System.Collections.Generic;
using System.Text;

namespace LD37.GameObjects
{
    abstract class CreepBehavior : Behavior
    {
        public Creep Creep => GameObject as Creep;
    }
}
