using Coldsteel;
using Coldsteel.Scripting;
using System;
using System.Collections.Generic;
using System.Text;

namespace LD37.GameObjects
{
    abstract class HasStatsBehavior : Behavior
    {
        public IStatsHolder HasStats => this.GameObject as IStatsHolder;
    }
}
