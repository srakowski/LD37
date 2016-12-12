using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LD37.GameObjects
{
    class CreepAggroBehavior : CreepBehavior
    {
        public override void Update()
        {
            if (Creep.SelectedAttackTarget != null)
                return;

            var thingToAttack = Scene.GameObjects.OfType<ICreepAttackable>()
                .FirstOrDefault(go => Vector2.Distance(go.Position, this.Transform.Position) < Creep.Stats.AggroRadius.Value);

            Creep.SelectedAttackTarget = thingToAttack;
        }
    }
}
