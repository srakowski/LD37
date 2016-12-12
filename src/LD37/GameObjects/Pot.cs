using Coldsteel;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Coldsteel.Physics;
using Coldsteel.Rendering;

namespace LD37.GameObjects
{
    class Pot : GameObject, IChampionAttackable
    {
        private BoxCollider _box;

        public Stats Stats { get; private set; } = new Stats();

        public Vector2 Position => Transform.Position;

        public Rectangle Bounds => _box.Bounds;

        public Hand Hand { get; internal set; }

        public Pot()
        {
            this.AddComponent(new SpriteRenderer("sprites/pot"));
            AddComponent(new AddHealthBarBehavior());
            AddComponent(_box = new BoxCollider(-48, -57, 96, 114));
            AddComponent(new DeathBehavior(true));
            Stats.Health.Baseline = 20;
        }
    }
}
