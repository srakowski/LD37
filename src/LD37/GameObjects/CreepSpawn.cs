using Coldsteel;
using Coldsteel.Rendering;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Coldsteel.Physics;

namespace LD37.GameObjects
{
    public class CreepSpawn : GameObject, IChampionAttackable
    {
        public bool IsEnabled { get; set; }

        private BoxCollider _box;

        public Stats Stats { get; private set; } = new Stats();

        public Vector2 Position => Transform.Position;

        public Rectangle Bounds => _box.Bounds;

        public CreepSpawn(ICreepAttackable ultimateTarget, int level)
        {
            AddComponent(new SpriteRenderer("sprites/creepspawn") { Layer = "item" });
            AddComponent(_box = new BoxCollider(-48, -48, 96, 96));
            AddComponent(new DeathBehavior());
            AddComponent(new AddHealthBarBehavior());
            AddComponent(new CreepSpawnBehavior(ultimateTarget, level));
            Stats.Health.Baseline = 30;
        }
    }
}
