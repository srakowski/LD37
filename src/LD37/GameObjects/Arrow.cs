using Coldsteel;
using Coldsteel.Physics;
using Coldsteel.Rendering;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace LD37.GameObjects
{
    class Arrow : GameObject
    {
        public Arrow()
        {
            AddComponent(new SpriteRenderer("sprites/arrow"));
            AddComponent(new RigidBody());
            AddComponent(new ArrowBehavior());
            AddComponent(new BoxCollider(-10, -32, 20, 64));
            this.Transform.Rotation = MathHelper.ToRadians(180);
        }
    }
}
