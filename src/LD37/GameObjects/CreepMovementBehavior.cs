using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LD37.GameObjects
{
    class CreepMovementBehavior : CreepBehavior
    {
        public override void Update()
        {
            Vector2 direction = Vector2.Zero;

            if (Creep.SelectedAttackTarget != null)
            {
                if (Vector2.Distance(Creep.SelectedAttackTarget.Position, this.Transform.Position) <
                    (Creep.Stats.AttackRadius.Value - 12f))
                {
                    RigidBody.Velocity = Vector2.Zero;
                    return;
                }

                direction = Creep.SelectedAttackTarget.Position - this.Transform.Position;
            }
            else
            {
                if (Vector2.Distance(Creep.UltimateTarget.Position, this.Transform.Position) <
                    (Creep.Stats.AttackRadius.Value - 12f))
                {
                    RigidBody.Velocity = Vector2.Zero;
                    return;
                }

                direction = Creep.UltimateTarget.Position - this.Transform.Position;
            }

            var closeCreep = Scene.GameObjects.Where(go => go is Creep && go != this.Creep && Vector2.Distance(this.Transform.Position, go.Transform.Position) < 72f)
                .OrderBy(go => Vector2.Distance(this.Transform.Position, go.Transform.Position))
                .FirstOrDefault();

            if (closeCreep != null)
                direction = Vector2.Transform(
                    this.Transform.Position - closeCreep.Transform.Position,
                    Matrix.Identity * Matrix.CreateRotationZ(MathHelper.ToRadians(90)));

            direction.Normalize();
            RigidBody.Velocity = direction * Creep.Stats.MovementSpeed.Value;
        }
    }
}
