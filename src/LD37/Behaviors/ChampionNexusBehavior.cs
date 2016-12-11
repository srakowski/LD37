using Coldsteel.Scripting;
using LD37.GameObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace LD37.Behaviors
{
    class ChampionNexusBehavior : Behavior
    {
        public ChampionNexus ChampionNexus => GameObject as ChampionNexus;

        public override void Update()
        {
            if (ChampionNexus.Stats.IsDead)
            {
                Destroy(ChampionNexus);
                return;
            }
        }
    }
}
