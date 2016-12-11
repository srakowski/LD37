using Coldsteel;
using LD37.Models;
using Microsoft.Xna.Framework;
using Coldsteel.Rendering;
using LD37.Behaviors;
using System;

namespace LD37.GameObjects
{
    class Champion : GameObject, ICreepTarget
    {
        private ChampionBehavior _behavior;

        public Vector2 Position => this.Transform.Position;

        public Stats Stats { get; set; } = new Stats();

        public Champion()
        {
            AddComponent(new SpriteRenderer("sprites/champion"));
            AddComponent(_behavior = new ChampionBehavior());
        }

        public void Attack(IChampionTarget target) => 
            _behavior.Attack(target);

        public void MoveTo(Vector2 position)
        {
            _behavior.MoveTo(position);
        }
    }
}
