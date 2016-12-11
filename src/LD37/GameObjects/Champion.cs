using Coldsteel;
using LD37.Models;
using Microsoft.Xna.Framework;
using Coldsteel.Rendering;
using LD37.Behaviors;
using System;
using Coldsteel.Physics;

namespace LD37.GameObjects
{
    public class Champion : GameObject, ICreepTarget
    {
        private ChampionBehavior _behavior;

        public Vector2 Position => this.Transform.Position;

        public Stats Stats { get; set; } = new Stats();

        public Champion()
        {
            AddComponent(new SpriteRenderer("sprites/champion"));
            AddComponent(_behavior = new ChampionBehavior());
            AddComponent(new RigidBody());
            AddComponent(new CameraController());
            Stats.AttackRadius.BaselineValue = 400f;
            Stats.AttackSpeed.BaselineValue = 1.5f;
            Stats.MovementSpeed.BaselineValue = 0.5f;
        }

        //public void Attack(IChampionTarget target) => 
        //    _behavior.Attack(target);

        public void MoveTo(Vector2 position)
        {
            _behavior.MoveTo(position);
        }

        internal void Shoot(Vector2 vector2)
        {
            _behavior.Shoot(vector2);
        }
    }
}
