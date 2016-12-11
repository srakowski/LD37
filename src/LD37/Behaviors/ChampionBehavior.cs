using Coldsteel.Fluent;
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

        private bool _inCooldown = false;

        internal void MoveTo(Vector2 worldPosition)
        {
            _target = null;
            _currentActivity?.Stop();
            _currentActivity = StartCoroutine(WalkToPosition(worldPosition));
        }

        internal void Shoot(Vector2 vector2)
        {
            if (_inCooldown)
                return;

            _inCooldown = true;
            Scene.Add(new Bullet(Champion, vector2).SetPosition(this.Transform.Position));
            StartCoroutine(AttackCooldown());
        }

        private IEnumerator AttackCooldown()
        {
            yield return WaitYieldInstruction.Create(Champion.Stats.CalculateAttackCooldownWait());
            _inCooldown = false;
        }

        //internal void Attack(IChampionTarget target)
        //{
        //    if (_inAttackCooldown)
        //        return;

        //    if (target == null)
        //        return;

        //    if (target.Stats.IsDead)
        //        return;

        //    _target = target;
        //    _currentActivity?.Stop();
        //    _currentActivity = null;
        //    if (Vector2.Distance(Transform.Position, target.Position) < Champion.Stats.AttackRadius.ActiveValue)
        //    {
        //        _inAttackCooldown = true;
        //        Scene.Add(new Bullet(target, AttackResolver.ResolvePhysicalAttack(Champion, target)).SetPosition(this.Transform.Position));
        //        StartCoroutine(AttackCooldown());
        //    }
        //    else
        //    {
        //        _currentActivity = StartCoroutine(MoveToAttack());
        //    }
        //}

        //private IEnumerator AttackCooldown()
        //{
        //    yield return WaitYieldInstruction.Create(Champion.Stats.CalculateAttackCooldownWait());
        //    _inAttackCooldown = false;
        //}

        //private IEnumerator MoveToAttack()
        //{
        //    while (Vector2.Distance(this.Transform.Position, _target.Position) > Champion.Stats.AttackRadius.ActiveValue)
        //    {
        //        StepTo(_target.Position);
        //        yield return null;
        //    }
        //    Attack(_target);
        //}

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
