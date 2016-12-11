using Coldsteel;
using Coldsteel.Scripting;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace LD37.Behaviors
{
    class CameraController : Behavior
    {
        private const float _speed = 1f;

        private IButtonControl Up { get; set; }
        private IButtonControl Down { get; set; }
        private IButtonControl Left { get; set; }
        private IButtonControl Right { get; set; }

        public override void Activate()
        {
            Up = Input.GetButtonControl("Up");
            Down = Input.GetButtonControl("Down");
            Left = Input.GetButtonControl("Left");
            Right = Input.GetButtonControl("Right");
        }

        public override void Update()
        {
            if (Up.IsDown()) this.Transform.Position += new Vector2(0, 1) * _speed * Delta;
            if (Down.IsDown()) this.Transform.Position += new Vector2(0, -1) * _speed * Delta;
            if (Left.IsDown()) this.Transform.Position += new Vector2(1, 0) * _speed * Delta;
            if (Right.IsDown()) this.Transform.Position += new Vector2(-1, 0) * _speed * Delta;
        }
    }
}
