using Coldsteel;
using Coldsteel.Physics;
using Coldsteel.Rendering;
using LD37.Behaviors;
using LD37.Models;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LD37.GameObjects
{
    class Creep : GameObject, IChampionTarget
    {
        public Stats Stats { get; set; } = new Stats();

        public Rectangle Bounds => this.Components.OfType<BoxCollider>().First().Bounds;

        public Vector2 Position => Transform.Position;

        protected Creep(ICreepTarget champion, ICreepTarget[] staticTargets)
        {
            Tags.Add("attackable");
            AddComponent(new CreepBehavior(champion, staticTargets));
            AddComponent(new SpriteRenderer("sprites/creep"));
            AddComponent(new RigidBody());
            AddComponent(new BoxCollider(-20, -20, 40, 40));
            AddComponent(new BoxRenderer(-20, -20, 40, 40)
            {
                Color = Color.Lime
            });
        }

        internal static Creep Create(CreepLevel level, ICreepTarget champion, ICreepTarget[] staticTargets)
        {
            return new Creep(champion, staticTargets);
        }
    }
}
