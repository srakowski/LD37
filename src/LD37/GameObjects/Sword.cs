using Coldsteel;
using Coldsteel.Rendering;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace LD37.GameObjects
{
    public class Sword : GameObject
    {
        public Sword()
        {
            Transform.Position = new Vector2(0, -72);
            AddComponent(new SpriteRenderer("sprites/sword"));
            AddComponent(new SwingBehavior());
            //AddComponent(new BoxRenderer(-5, -5, 10, 10) { Color = Color.Red });
        }
    }
}
