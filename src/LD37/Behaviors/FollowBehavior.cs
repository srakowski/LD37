using Coldsteel;
using Coldsteel.Scripting;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace LD37.Behaviors
{
    class FollowBehavior : Behavior
    {
        private GameObject _target;

        public FollowBehavior(GameObject target)
        {
            _target = target;
        }

        public override void Update()
        {
            if (_target.Transform.Position == this.Transform.Position)
                return;

            this.Transform.Position = Vector2.SmoothStep(
                this.Transform.Position, 
                _target.Transform.Position, 0.1f);
        }
    }
}
