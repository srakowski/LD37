using Coldsteel.Scripting;
using System;
using System.Collections.Generic;
using System.Text;

namespace LD37.GameObjects
{
    class AddHealthBarBehavior : Behavior
    {
        public override void Activate()
        {
            var hb = new HealthBar(this.GameObject as IStatsHolder);
            this.Scene.Add(hb);
            hb.Transform.SetParent(this.GameObject.Transform);
            this.Destroy(this);
        }
    }
}
