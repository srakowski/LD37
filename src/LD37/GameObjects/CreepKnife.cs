using Coldsteel;
using Coldsteel.Fluent;
using Coldsteel.Rendering;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace LD37.GameObjects
{
    class CreepKnife : GameObject
    {
        public CreepKnife()
        {
            Transform.Position = new Vector2(0, -48);
            AddComponent(new SpriteRenderer("sprites/creepknife"));
        }
    }
}
