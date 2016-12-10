using LD37.Models.Items;
using System;
using System.Collections.Generic;
using System.Text;

namespace LD37.Models
{
    abstract class Item
    {
        public int Price { get; set; }

        public Stats Stats { get; set; }

        public void Affect(Stats stats)
        {
        }

        public void Unaffect(Stats stats)
        {
        }

        public static Item Empty => new EmptyItem();
    }
}
