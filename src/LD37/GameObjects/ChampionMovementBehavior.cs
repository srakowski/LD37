using Microsoft.Xna.Framework;

namespace LD37.GameObjects
{
    class ChampionMovementBehavior : ChampionBehavior
    {
        public override void Update()
        {
            this.Transform.Position =
                new Vector2(MathHelper.Clamp(Transform.Position.X, -750, 700),
                    MathHelper.Clamp(Transform.Position.Y, -12, 1125));

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
                RigidBody.Velocity = direction * Champion.Stats.MovementSpeed.Value;
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
                RigidBody.Velocity = direction * Champion.Stats.MovementSpeed.Value;
            }
        }
    }
}
