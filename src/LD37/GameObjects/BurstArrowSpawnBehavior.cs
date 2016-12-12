using Coldsteel.Fluent;
using Coldsteel.Scripting;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace LD37.GameObjects
{
    class BurstArrowSpawnBehavior : Behavior
    {
        public override void Activate()
        {
            StartCoroutine(SpawnArrows());
        }

        private IEnumerator SpawnArrows()
        {
            while (true)
            {
                if ((GameObject as ArrowSpawn).IsEnabled)
                {
                    for (var i = 0; i < 3; i++)
                    {
                        var arrow = new Arrow().SetPosition(this.Transform.Position);
                        Scene.Add(arrow);
                        yield return WaitYieldInstruction.Create(600);
                    }
                }
                yield return WaitYieldInstruction.Create(3000);
            }
        }
    }
}
