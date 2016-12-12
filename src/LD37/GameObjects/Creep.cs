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
        public ICreepAttackable UltimateTarget { get; set; }

        public ICreepAttackable SelectedAttackTarget { get; set; }

        private BoxCollider _box;

        public Stats Stats { get; private set; } = new Stats();

        public Vector2 Position => Transform.Position;

        public Rectangle Bounds => _box.Bounds;

        public Hand Hand { get; internal set; }

        public Creep(ICreepAttackable ultimateTarget)
        {
            this.UltimateTarget = ultimateTarget;
            this.AddComponent(new SpriteRenderer("sprites/creep"));
            AddComponent(new AddHealthBarBehavior());
            AddComponent(new CreepAggroBehavior());
            AddComponent(new CreepMovementBehavior());
            AddComponent(new CreepAttackBehavior());
            AddComponent(new AddCreepKnifeBehavior());
            AddComponent(new RigidBody());
            AddComponent(_box = new BoxCollider(-48, -48, 96, 96));
            AddComponent(new DeathBehavior());
            Stats.MovementSpeed.Baseline = 0.15f;
            Stats.Health.Baseline = 20;
            Stats.AggroRadius.Baseline = 300;
            Stats.AttackRadius.Baseline = 100;
            Stats.AttackDamage.Baseline = 1;
            Stats.AttackSpeed.Baseline = 0.5f;
        }
    }
}
