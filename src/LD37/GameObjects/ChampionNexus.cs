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
    class ChampionNexus : GameObject, ICreepTarget
    {
        public Vector2 Position => this.Transform.Position;

        public Stats Stats { get; set; } = new Stats();

        public ChampionNexus()
        {
            AddComponent(new SpriteRenderer("sprites/pnexus"));
            AddComponent(new ChampionNexusBehavior());
        }
    }
}
