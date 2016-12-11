using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace LD37.Models
{
    interface IAttackable
    {
        Vector2 Position { get; }
        Stats Stats { get; }
    }
}
