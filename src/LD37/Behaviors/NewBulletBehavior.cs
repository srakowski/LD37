using Coldsteel.Scripting;
using LD37.Models;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace LD37.Behaviors
{
    class NewBulletBehavior : Behavior
    {
        private Vector2 _dir;

        public NewBulletBehavior(IAttackable attacker, Vector2 direction)
        {
            _dir = direction;
        }

        public override void Activate()
        {
            _dir.Normalize();
            RigidBody.Velocity = _dir * 1.2f;
        }
    }
}
