using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace LD37.GameObjects
{
    public interface IChampionAttackable : IStatsHolder
    {
        Vector2 Position { get; }
        Rectangle Bounds { get; }
    }
}
