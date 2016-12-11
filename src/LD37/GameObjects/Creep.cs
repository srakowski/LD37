using Coldsteel;
using Coldsteel.Physics;
using Coldsteel.Rendering;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;

namespace LD37.GameObjects
{
    public class Creep : GameObject, IStatsHolder, IChampionAttackable
    {
        private BoxCollider _box;

        public Stats Stats { get; private set; } = new Stats();

        public Vector2 Position => Transform.Position;

        public Rectangle Bounds => _box.Bounds;

        public Creep()
        {
            this.AddComponent(new SpriteRenderer("sprites/creep"));
            AddComponent(new AddHealthBarBehavior());
            AddComponent(_box = new BoxCollider(-48, -48, 96, 96));
            AddComponent(new DeathBehavior());
            Stats.Health.Baseline = 100;
        }
    }
}
