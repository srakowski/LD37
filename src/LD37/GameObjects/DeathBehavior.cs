using Coldsteel;
using Coldsteel.Fluent;
using Coldsteel.Rendering;
using Coldsteel.Scripting;
using System;
using System.Collections.Generic;
using System.Text;

namespace LD37.GameObjects
{
    class DeathBehavior : Behavior
    {
        private bool _dropTomato = false;

        private IStatsHolder StatsHolder => GameObject as IStatsHolder;

        public DeathBehavior()
        {
        }

        public DeathBehavior(bool droptomato = false)
        {
            _dropTomato = droptomato;
        }

        public override void Update()
        {
            if (StatsHolder.Stats.IsDead)
            {
                this.Destroy(GameObject);
                if (GameObject is Champion)
                {
                    Scene.Add(new GameObject()
                        .SetPosition(this.Transform.Position)
                        .Add(new SpriteRenderer("sprites/dead")));
                }

                if (_dropTomato)
                    Scene.Add(new Tomato().SetPosition(GameObject.Transform.Position));
            }
        }
    }
}
