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
    public class Champion : GameObject, IStatsHolder
    {
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

            Stats.AttackRadius.Baseline = 140f;
            Stats.AttackSpeed.Baseline = 2f;
            Stats.AttackDamage.Baseline = 10f;
            //AddComponent(new SimulateDamageBehavior(this));
        }
    }
}
