using LD37.GameObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace LD37.Models
{
    interface ICreepFactory
    {
        Creep Create(CreepLevel level);
    }
}
