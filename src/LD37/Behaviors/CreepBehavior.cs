using Coldsteel;
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
    class CreepBehavior : Behavior
    {
        private ICreepTarget _champion;

        private int _minNextTarget = 0;

        private bool _mayAttack = true;

        private Creep Creep => GameObject as Creep;

        private ICreepTarget[] _staticCreepTargets;

        public int AggroRadius { get; set; } = 300;

        public CreepBehavior(ICreepTarget champion, ICreepTarget[] staticCreepTargets)
        {
            this._champion = champion;
            this._staticCreepTargets = staticCreepTargets;
        }

        public override void Update()
        {
            if (Creep.Stats.IsDead)
            {
                Destroy(Creep);
                return;
            }

            var target = GetBestTarget();
            if (target == null)
                return;

            this.RigidBody.Velocity = Vector2.Zero;
            if (Vector2.Distance(Transform.Position, target.Position) < Creep.Stats.AttackRadius.ActiveValue)
                Attack(target);
            else
                MoveToward(target);

            // get best target
            // if target is within attack range, attack
            // if target is outside of attack range, move to target
        }

        private void Attack(ICreepTarget target)
        {
            if (!_mayAttack)
                return;

            _mayAttack = false;
            // TODO: execute attack

            StartCoroutine(AttackCooldown(Creep.Stats.AttackSpeed.ActiveValue));
        }

        private IEnumerator AttackCooldown(float attackSpeed)
        {
            // TODO: move to stats
            yield return WaitYieldInstruction.Create(1000 - (int)(1000 * (2.0f - attackSpeed)));
            _mayAttack = true;
        }

        private void MoveToward(ICreepTarget target)
        {
            var direction = target.Position - this.Transform.Position;
            direction.Normalize();
            RigidBody.Velocity = direction * Creep.Stats.MovementSpeed.ActiveValue;
        }

        private ICreepTarget GetBestTarget()
        {
            if (Vector2.Distance(Transform.Position, _champion.Position) < AggroRadius)
                return _champion;

            for (var i = _minNextTarget; i < _staticCreepTargets.Length; i++)
                if (!_staticCreepTargets[i].IsDestroyed)
                {
                    _minNextTarget = i;
                    return _staticCreepTargets[i];
                }

            return null;
        }
    }
}
