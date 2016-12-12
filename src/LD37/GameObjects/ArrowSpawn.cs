using Coldsteel;
using Coldsteel.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace LD37.GameObjects
{
    class ArrowSpawn : GameObject
    {
        public bool IsEnabled { get; set; } = false;

        static Random _rand = new Random();

        public ArrowSpawn()
        {
            this.AddComponent(new SpriteRenderer("sprites/arrowspawn"));
            var val = _rand.Next(0, 100);
            if (val < 50)
                this.AddComponent(new ContinualArrowSpawnBehavior());
            else
                this.AddComponent(new BurstArrowSpawnBehavior());
        }
    }
}
