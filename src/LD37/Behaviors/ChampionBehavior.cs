using Coldsteel.Scripting;
using LD37.GameObjects;
using LD37.Models;
using Microsoft.Xna.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace LD37.Behaviors
{
    class ChampionBehavior : Behavior
    {
        private IChampionTarget _target;

        private Coroutine _currentActivity;

        private Champion Champion => GameObject as Champion;

        internal void MoveTo(Vector2 worldPosition)
        {
            _target = null;
            _currentActivity?.Stop();
            _currentActivity = StartCoroutine(WalkToPosition(worldPosition));
        }

        internal void Attack(IChampionTarget target)
        {
            if (target == null)
                return;

            _target = target;
            _currentActivity?.Stop();
            _currentActivity = null;
            if (Vector2.Distance(Transform.Position, target.Position) < Champion.Stats.AttackRadius.ActiveValue)
            {
                AttackResolver.ResolvePhysicalAttack(Champion, target);
                _currentActivity = StartCoroutine(AttackCooldown());
            }
            else
            {
                _currentActivity = StartCoroutine(MoveToAttack());
            }
        }

        private IEnumerator AttackCooldown()
        {
            // TODO: move to stats
            yield return WaitYieldInstruction.Create(Champion.Stats.CalculateAttackCooldown());
            Attack(_target);
        }

        private IEnumerator MoveToAttack()
        {
            while (Vector2.Distance(this.Transform.Position, _target.Position) > Champion.Stats.AttackRadius.ActiveValue)
            {
                StepTo(_target.Position);
                yield return null;
            }
            Attack(_target);
        }

        private IEnumerator WalkToPosition(Vector2 worldPosition)
        {
            while (Vector2.Distance(this.Transform.Position, worldPosition) > 3.0f)
            {
                StepTo(worldPosition);
                yield return null;
            }
        }

        private void StepTo(Vector2 worldPosition)
        {
            var direction = worldPosition - this.Transform.Position;
            direction.Normalize();
            this.Transform.Position += direction * Champion.Stats.MovementSpeed.ActiveValue * Delta;
        }
    }
}
