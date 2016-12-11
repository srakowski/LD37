using Coldsteel.Scripting;
using System;
using System.Collections.Generic;
using System.Text;

namespace LD37.GameObjects
{
    class HealthBarBehavior : Behavior
    {
        public HealthBar HealthBar => GameObject as HealthBar;

        public IStatsHolder StatsHolder { get; private set; }

        public HealthBarBehavior(IStatsHolder statsHolder)
        {
            StatsHolder = statsHolder;
        }

        public override void Update()
        {
            HealthBar.HealthPercentage = StatsHolder.Stats.Health.Value / StatsHolder.Stats.Health.BaselineValue;
        }
    }
}
