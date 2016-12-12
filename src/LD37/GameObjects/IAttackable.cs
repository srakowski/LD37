using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace LD37.GameObjects
{
    public interface IAttackable : IStatsHolder
    {
        Vector2 Position { get; }
    }
}
