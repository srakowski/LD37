using Coldsteel.Fluent;
using System;
using System.Collections.Generic;
using System.Text;

namespace LD37.GameObjects
{
    class AddCreepKnifeBehavior : CreepBehavior
    {
        public override void Activate()
        {
            var hand = new Hand();
            Scene.Add(hand);
            hand.SetParent(Creep);

            var creepKnife = new CreepKnife();
            Scene.Add(creepKnife);
            creepKnife.SetParent(hand);
            Destroy(this);

            Creep.Hand = hand;
        }
    }
}
