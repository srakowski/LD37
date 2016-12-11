using Coldsteel;
using Coldsteel.Rendering;
using LD37.Behaviors;
using LD37.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;

namespace LD37.GameObjects
{
    class Nexus : GameObject, IChampionTarget
    {
        private NexusBehavior _behavior;

        public Stats Stats { get; set; } = new Stats();

        protected Nexus(NexusBehavior behavior, string textureAssetName)
        {
            Tags.Add("attackable");
            _behavior = behavior;
            AddComponent(behavior);
            AddComponent(new SpriteRenderer(textureAssetName));
        }

        public Rectangle Bounds => new Rectangle(
            Transform.Position.ToPoint() - new Point(48, 48),
            new Point(96, 96));

        public Vector2 Position => Transform.Position;
        
        public static Nexus CreateNexus(int level, ICreepFactory creepFactory)
        {
            switch (level)
            {
                case 1: return CreateNexus(creepFactory, CreepLevel.Level1, "sprites/nexus1");
                case 2: return CreateNexus(creepFactory, CreepLevel.Level2, "sprites/nexus2");
                case 3: return CreateNexus(creepFactory, CreepLevel.Level3, "sprites/nexus3");
                case 4: return CreateNexus(creepFactory, CreepLevel.Level4, "sprites/nexus4");
                case 5: return CreateNexus(creepFactory, CreepLevel.Level5, "sprites/nexus5");
            }

            throw new Exception($"invalid nexus level {level}");
        }

        private static Nexus CreateNexus(ICreepFactory creepFactory, CreepLevel creepLevel, string textureAssetName)
        {
            var behavior = new NexusBehavior(creepFactory, creepLevel);
            return new Nexus(behavior, textureAssetName);
        }

        internal void Activate() => _behavior.IsActive = true;
    }
}
