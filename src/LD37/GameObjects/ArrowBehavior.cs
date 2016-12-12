using Coldsteel.Physics;
using Coldsteel.Scripting;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LD37.GameObjects
{
    class ArrowBehavior : Behavior
    {
        private static SoundEffect NailedIt { get; set; }

        private Champion Champion { get; set; }

        private BoxCollider ChampionCollider { get; set; }

        public override void Activate()
        {
            Champion = Scene.GameObjects.OfType<Champion>().FirstOrDefault();
            ChampionCollider = Champion?.Components.OfType<BoxCollider>().First();
            if (NailedIt == null)
            {
                NailedIt = Content.Load<SoundEffect>("audio/hurt");
            }
        }

        public override void Update()
        {
            if (Champion == null)
            {
                Destroy(this);
                return;
            }

            if (Transform.Position.X < -750 || Transform.Position.X > 700 ||
                Transform.Position.Y < -100 || Transform.Position.Y > 1125)
            {
                Destroy(GameObject);
                return;
            }

            if (this.ChampionCollider.Bounds.Intersects((this.Collider as BoxCollider).Bounds))
            {
                NailedIt.Play();
                Champion.Stats.TakeDamage(2);
                Destroy(GameObject);
                return;
            }
            else
            {
                var creeps = Scene.GameObjects.OfType<Creep>().Where(c => !c.Stats.IsDead);
                foreach (var creep in creeps)
                {
                    if ((this.Collider as BoxCollider).Bounds.Intersects(creep.Bounds))
                    {
                        creep.Stats.TakeDamage(2);
                        Destroy(GameObject);
                        return;
                    }
                }
            }

            var dir = new Vector2(0, 1);
            dir.Normalize();
            this.RigidBody.Velocity = dir * 0.4f;
        }
    }
}
