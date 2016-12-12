using Coldsteel;
using Coldsteel.Physics;
using Microsoft.Xna.Framework.Audio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LD37.GameObjects
{
    class ChampionPickupBehavior : ChampionBehavior
    {
        private static SoundEffect Pickup { get; set; }

        public override void Activate()
        {
            Pickup = Content.Load<SoundEffect>("audio/pickup");
        }

        public override void Update()
        {
            var pickups = Scene.GameObjects.OfType<IRestoreHealth>();
            if (!pickups.Any())
                return;

            foreach (var pickup in pickups)
            {
                var go = pickup as GameObject;
                var collider = go.Components.OfType<BoxCollider>().FirstOrDefault();
                if (collider?.Bounds.Intersects((this.Collider as BoxCollider).Bounds) ?? false)
                {
                    Destroy(go);
                    Champion.Stats.RestoreHealth(2);
                    Pickup.Play();
                }
            }
        }
    }
}
