using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace LD37.Models
{
    interface ICreepTarget : IAttackable
    {
        bool IsDestroyed { get; }
    }
}
