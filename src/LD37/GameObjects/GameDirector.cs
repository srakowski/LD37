using Coldsteel;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace LD37.GameObjects
{
    public class GameDirector : GameObject
    {
        public IEnumerable<Vector2> CreepSpawnerLocations { get; set; }

        public ChampionNexus ChampionNexus { get; set; }

        public Champion Champion { get; set; }

        public GameDirector(IEnumerable<Vector2> _creepSpawnerLocations,
            ChampionNexus championNexus, Champion champion)
        {
            CreepSpawnerLocations = _creepSpawnerLocations;
            ChampionNexus = championNexus;
            Champion = champion;
            AddComponent(new GameFlowBehavior());
        }
    }
}
