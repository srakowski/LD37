using Coldsteel;
using LD37.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;

namespace LD37.GameObjects
{
    class Tower : GameObject, ICreepTarget
    {
        public Vector2 Position => this.Transform.Position;

        public Stats Stats { get; set; } = new Stats();
    }
}
