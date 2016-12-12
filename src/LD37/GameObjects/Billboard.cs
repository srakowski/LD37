using Coldsteel;
using Coldsteel.Rendering;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace LD37.GameObjects
{
    public class Billboard : GameObject
    {
        public TextRenderer TextRenderer { get; set; }

        public Billboard()
        {
            AddComponent(TextRenderer = new TextRenderer("fonts/hud", "Derp") {
                Layer = "pointer",
                Color = Color.WhiteSmoke
            });

            AddComponent(new ProgressionBehavior(this.TextRenderer));
        }
    }
}
