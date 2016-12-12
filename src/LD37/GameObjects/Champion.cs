using Coldsteel;
using Coldsteel.Physics;
using Coldsteel.Rendering;
using Microsoft.Xna.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace LD37.GameObjects
{
    public class Champion : GameObject, IStatsHolder, ICreepAttackable
    {
        public Vector2 Position => Transform.Position;

        public Vector2? TargetDestination { get; set; }

        public Stats Stats { get; private set; } = new Stats();

        public Hand Hand { get; set; }

        public Sword Sword { get; set; }

        public IChampionAttackable SelectedAttackTarget { get; internal set; }
        
        public Champion()
        {
            AddComponent(new RigidBody());
            AddComponent(new SpriteRenderer("sprites/champion"));
            AddComponent(new ChampionLookBehavior());
            AddComponent(new ChampionController());
            AddComponent(new ChampionMovementBehavior());
            AddComponent(new AddHealthBarBehavior());
            AddComponent(new ChampionAttackBehavior());
            AddComponent(new ChampionPickupBehavior());
            AddComponent(new DeathBehavior());
            AddComponent(new BoxCollider(-48, -48, 96, 96));
            Stats.Health.Baseline = 10f;
            Stats.MovementSpeed.Baseline = 0.3f;
            Stats.AttackRadius.Baseline = 160f;
            Stats.AttackSpeed.Baseline = 1f;
            Stats.AttackDamage.Baseline = 10f;
            //AddComponent(new SimulateDamageBehavior(this));
        }
    }
}
