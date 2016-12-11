using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace LD37.GameObjects
{
    class ChampionMovementBehavior : ChampionBehavior
    {
        public float MovementSpeed { get; private set; } = 0.3f;

        public override void Update()
        {
            if (!Champion.TargetDestination.HasValue && Champion.SelectedAttackTarget == null)
                return;

            if (Champion.TargetDestination.HasValue)
            {
                if (Vector2.Distance(Champion.TargetDestination.Value, Champion.Transform.Position) < 24f)
                {
                    RigidBody.Velocity = Vector2.Zero;
                    Champion.TargetDestination = null;
                    return;
                }

                var direction = Champion.TargetDestination.Value -
                    this.Champion.Transform.Position;
                direction.Normalize();
                RigidBody.Velocity = direction * MovementSpeed;
            }
            else if (Champion.SelectedAttackTarget != null)
            {
                if (Vector2.Distance(Champion.SelectedAttackTarget.Position, this.Transform.Position) < 
                    (Champion.Stats.AttackRadius.Value - 12f))
                {
                    RigidBody.Velocity = Vector2.Zero;
                    return;
                }

                var direction = Champion.SelectedAttackTarget.Position - this.Champion.Transform.Position;
                direction.Normalize();
                RigidBody.Velocity = direction * MovementSpeed;
            }
        }
    }
}
