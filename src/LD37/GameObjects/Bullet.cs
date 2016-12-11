using Coldsteel;
using Coldsteel.Physics;
using Coldsteel.Rendering;
using LD37.Behaviors;
using LD37.Models;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace LD37.GameObjects
{
    class Bullet : GameObject
    {
        public Bullet(IAttackable sender, Vector2 direction)
        {
            AddComponent(new SpriteRenderer("sprites/bullet"));
            AddComponent(new NewBulletBehavior(sender, direction));
            AddComponent(new RigidBody());
        }
    }
}
