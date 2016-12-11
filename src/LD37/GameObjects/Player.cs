using Coldsteel;
using Coldsteel.Rendering;
using LD37.Behaviors;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LD37.GameObjects
{
    class Player : GameObject
    {
        private ChampionControllerBehavior _behavior;

        public GameObject Camera
        {
            get { return _behavior.Camera.GameObject; }
            set { _behavior.Camera = value.Components.OfType<Camera>().First(); }
        }

        public Champion Champion
        {
            get { return _behavior.Champion; }
            set { _behavior.Champion = value; }
        }

        public Player()
        {
            AddComponent(new SpriteRenderer("sprites/pointer")
            {
                Origin = Vector2.Zero,
                Layer = "hud"
            });
            AddComponent(_behavior = new ChampionControllerBehavior());
        }

    }
}
