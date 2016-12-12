using Coldsteel;
using Coldsteel.Rendering;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace LD37.GameObjects
{
    public class ChampionNexus : GameObject, ICreepAttackable
    {
        public Stats Stats { get; } = new Stats();

        public Vector2 Position => this.Transform.Position;

        public ChampionNexus()
        {
            //AddComponent(new SpriteRenderer("sprites/pnexus") { Layer = "item" });
            //AddComponent(new DeathBehavior());
            //AddComponent(new AddHealthBarBehavior());
            //Stats.Health.Baseline = 10000;
        }
    }
}
