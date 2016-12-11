using Coldsteel;
using Coldsteel.Physics;
using Coldsteel.Scripting;
using LD37.GameObjects;
using LD37.Models;
using Microsoft.Xna.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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

        private bool _mayChangeDir = true;

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
            {
                Attack(target);
            }
            else
            {
                MoveToward(target);
            }

            // get best target
            // if target is within attack range, attack
            // if target is outside of attack range, move to target
        }

        private void Attack(ICreepTarget target)
        {
            if (!_mayAttack)
                return;

            _mayAttack = false;
            AttackResolver.ResolvePhysicalAttack(Creep, target);
            StartCoroutine(AttackCooldown(Creep.Stats.AttackSpeed.ActiveValue));
        }

        private IEnumerator AttackCooldown(float attackSpeed)
        {
            yield return WaitYieldInstruction.Create(Creep.Stats.CalculateAttackCooldownWait());
            _mayAttack = true;
        }

        private void MoveToward(ICreepTarget target)
        {
            if (!_mayChangeDir)
                return;

            var directionIWantToGoIn = target.Position - this.Transform.Position;

            var closeCreep = Scene.GameObjects.Where(go => go is Creep && go != this.Creep &&
                Vector2.Distance(this.Transform.Position, go.Transform.Position) < 48f)
                .OrderBy(go => Vector2.Distance(this.Transform.Position, go.Transform.Position))
                .FirstOrDefault();

            if (closeCreep != null)
                directionIWantToGoIn = Vector2.Transform(
                    this.Transform.Position - closeCreep.Transform.Position,
                    Matrix.Identity * Matrix.CreateRotationZ(MathHelper.ToRadians(90)));

            directionIWantToGoIn.Normalize();
            RigidBody.Velocity = directionIWantToGoIn * Creep.Stats.MovementSpeed.ActiveValue;

            StartCoroutine(GoLikeThisForABit());
        }

        private IEnumerator GoLikeThisForABit()
        {
            yield return WaitYieldInstruction.Create(1000);
            _mayChangeDir = true;
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
