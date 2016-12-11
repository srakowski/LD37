using Coldsteel;
using LD37.Behaviors;
using LD37.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LD37.GameObjects
{
    class Lane : GameObject, ICreepFactory
    {
        private Champion _champion;

        private Tower _tower1;

        private Tower _tower2;

        private ChampionNexus _championNexus;

        private LaneBehavior _laneBehavior;

        public Lane(
            Champion champion,
            Tower tower1,
            Tower tower2,
            ChampionNexus championNexus)
        {
            _champion = champion;
            _tower1 = tower1;
            _tower2 = tower2;
            _championNexus = championNexus;
            _laneBehavior = new LaneBehavior();
            AddComponent(_laneBehavior);
        }

        public void PushNexus(Nexus nexus) => _laneBehavior.PushNexus(nexus);

        public Creep Create(CreepLevel level) =>
            Creep.Create(level, _champion, new ICreepTarget[] 
            {
                _tower1,
                _tower2,
                _championNexus
            });
    }
}
