using Coldsteel;
using LD37.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Coldsteel.Rendering;
using LD37.Behaviors;

namespace LD37.GameObjects
{
    class Tower : GameObject, ICreepTarget
    {
        public Vector2 Position => this.Transform.Position;

        public Stats Stats { get; set; } = new Stats();

        public Tower()
        {
            AddComponent(new SpriteRenderer("sprites/tower"));
            AddComponent(new TowerBehavior());
            Stats.Health.BaselineValue = 10000;
            Stats.AttackRadius.BaselineValue = 400f;
            Stats.AttackSpeed.BaselineValue = 1.3f;
        }
    }
}
