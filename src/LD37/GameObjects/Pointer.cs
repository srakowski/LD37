using Coldsteel;
using Coldsteel.Rendering;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace LD37.GameObjects
{
    public class Pointer : GameObject
    {
        private PointerBehavior _pointerBehavior;

        public Pointer()
        {
            AddComponent(new SpriteRenderer("sprites/pointer")
            {
                Layer = "pointer",
                Origin = Vector2.Zero
            });
            AddComponent(_pointerBehavior = new PointerBehavior());
        }
    }
}
