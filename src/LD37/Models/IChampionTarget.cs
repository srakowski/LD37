using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace LD37.Models
{
    interface IChampionTarget : IAttackable
    {
        Rectangle Bounds { get; }
        
    }
}
