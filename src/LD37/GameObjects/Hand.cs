using Coldsteel;
using Coldsteel.Rendering;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace LD37.GameObjects
{
    public class Hand : GameObject
    {
        private SwingBehavior _swingBehavior;
        public bool IsLeft
        {
            set { _swingBehavior.IsLeft = value; }
        }

        public Hand()
        {
            this.Transform.Position = new Vector2(0, 48);
            Transform.Rotation = MathHelper.ToRadians(45);
            //AddComponent(new BoxRenderer(-5, -5, 10, 10) { Color = Color.Red });
            AddComponent(_swingBehavior = new SwingBehavior());
        }

        public bool IsSwinging => _swingBehavior.IsSwinging;
        public void Swing() => _swingBehavior.BeginSwing();
    }
}
