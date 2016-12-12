using Coldsteel;
using Coldsteel.Physics;
using Coldsteel.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace LD37.GameObjects
{
    class Tomato : GameObject, IRestoreHealth
    {
        public Tomato()
        {
            AddComponent(new SpriteRenderer("sprites/tomato"));
            AddComponent(new BoxCollider(-32, -32, 64, 64));
        }
    }
}
