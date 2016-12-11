using Coldsteel.Fluent;
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
    class TowerBehavior : Behavior
    {
        public Tower Tower => GameObject as Tower;

        private bool _inCooldown = false;

        public override void Update()
        {
            if (Tower.Stats.IsDead)
            {
                Destroy(Tower);
                return;
            }

            if (_inCooldown)
                return;

            var creepNearMe = Scene.GameObjects.OfType<Creep>()
                .Where(c => Vector2.Distance(this.Transform.Position, c.Transform.Position) < Tower.Stats.AttackRadius.ActiveValue)
                .OrderBy(c => Vector2.Distance(this.Transform.Position, c.Transform.Position) < Tower.Stats.AttackRadius.ActiveValue)
                .FirstOrDefault();

            if (creepNearMe == null)
                return;

            _inCooldown = true;
            Scene.Add(new Bullet(Tower, creepNearMe.Transform.Position - this.Transform.Position).SetPosition(this.Transform.Position));
            StartCoroutine(AttackCooldown());
        }

        private IEnumerator AttackCooldown()
        {
            yield return WaitYieldInstruction.Create(Tower.Stats.CalculateAttackCooldownWait());
            _inCooldown = false;
        }
    }
}
