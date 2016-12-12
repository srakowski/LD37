using Coldsteel.Scripting;
using Microsoft.Xna.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace LD37.GameObjects
{
    class CreepAttackBehavior : CreepBehavior
    {
        private Coroutine _cooldown = null;

        public override void Update()
        {
            if (_cooldown != null)
                return;

            if (Creep.SelectedAttackTarget != null)
            {                
                if (Vector2.Distance(Creep.SelectedAttackTarget.Position, Transform.Position) < Creep.Stats.AttackRadius.Value)
                {
                    Creep.Hand.Swing();
                    var dmg = Stats.ResolveDamage(Creep.Stats, Creep.SelectedAttackTarget.Stats);
                    Creep.SelectedAttackTarget.Stats.TakeDamage(dmg);
                    _cooldown = StartCoroutine(AttackCooldown());
                }
            }
            else
            {
                if (Vector2.Distance(Creep.UltimateTarget.Position, Transform.Position) < Creep.Stats.AttackRadius.Value)
                {
                    Creep.Hand.Swing();
                    var dmg = Stats.ResolveDamage(Creep.Stats, Creep.UltimateTarget.Stats);
                    Creep.UltimateTarget.Stats.TakeDamage(dmg);
                    _cooldown = StartCoroutine(AttackCooldown());
                }
            }
        }

        private IEnumerator AttackCooldown()
        {
            yield return WaitYieldInstruction.Create(Creep.Stats.CalculatedAttackCooldownWait());
            _cooldown = null;
        }
    }
}
