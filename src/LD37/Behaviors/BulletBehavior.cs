using Coldsteel.Scripting;
using System;
using System.Collections.Generic;
using System.Text;
using LD37.Models;
using Microsoft.Xna.Framework;

namespace LD37.Behaviors
{
    class BulletBehavior : Behavior
    {
        private IAttackable _target;

        private Vector2 _initPos;

        private float _distToTarget;

        private float _dmg;

        public BulletBehavior(IAttackable target, float dmg)
        {
            this._target = target;
            this._dmg = dmg;
        }

        public override void Activate()
        {
            _initPos = Transform.Position;
            _distToTarget = Vector2.Distance(_target.Position, this.Transform.Position) * 1.5f;
            var dir = (_target.Position - this.Transform.Position);
            dir.Normalize();
            this.RigidBody.Velocity = dir * 1f;
        }

        public override void Update()
        {
            if (Vector2.Distance(Transform.Position, _initPos) > _distToTarget ||
                Vector2.Distance(Transform.Position, _target.Position) < 12f)
            {
                _target.Stats.TakeDamage(_dmg);
                this.Destroy(GameObject);
                return;
            }

            if (_target.Stats.IsDead)
            {
                this.Destroy(GameObject);
                return;
            }

            var dir = (_target.Position - this.Transform.Position);
            dir.Normalize();
            this.RigidBody.Velocity = dir * 1f;
        }


    }
}
