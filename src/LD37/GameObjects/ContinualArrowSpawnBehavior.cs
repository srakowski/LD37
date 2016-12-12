using Coldsteel.Fluent;
using Coldsteel.Scripting;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace LD37.GameObjects
{
    class ContinualArrowSpawnBehavior : Behavior
    {
        public override void Activate()
        {
            base.Activate();
            StartCoroutine(SpawnArrows());
        }

        private IEnumerator SpawnArrows()
        {
            while (true)
            {
                if ((GameObject as ArrowSpawn).IsEnabled)
                {
                    var arrow = new Arrow().SetPosition(this.Transform.Position);
                    Scene.Add(arrow);
                }
                yield return WaitYieldInstruction.Create(1300);
            }
        }
    }
}
