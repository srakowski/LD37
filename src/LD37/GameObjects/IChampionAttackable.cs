﻿using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace LD37.GameObjects
{
    public interface IChampionAttackable : IAttackable
    {
        Rectangle Bounds { get; }
    }
}
