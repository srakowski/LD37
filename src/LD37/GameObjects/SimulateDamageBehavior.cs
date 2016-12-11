using Coldsteel.Scripting;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace LD37.GameObjects
{
    class SimulateDamageBehavior : Behavior
    {
        private IStatsHolder _statsHolder;

        public SimulateDamageBehavior(IStatsHolder statsHolder)
        {
            _statsHolder = statsHolder;
        }

        public override void Activate()
        {
            StartCoroutine(SimulateDamage());
        }

        private IEnumerator SimulateDamage()
        {
            while (!_statsHolder.Stats.IsDead)
            {
                _statsHolder.Stats.TakeDamage(0.1f);
                yield return WaitYieldInstruction.Create(300);
            }
        }
    }
}
