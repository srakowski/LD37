using Coldsteel.Scripting;
using System;
using System.Collections.Generic;
using System.Text;

namespace LD37.GameObjects
{
    class DeathBehavior : Behavior
    {
        private IStatsHolder StatsHolder => GameObject as IStatsHolder;

        public DeathBehavior()
        {
        }

        public override void Update()
        {
            if (StatsHolder.Stats.IsDead)
            {
                this.Destroy(GameObject);
            }
        }
    }
}
