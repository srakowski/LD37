using LD37.Models.Items;

namespace LD37.Models
{
    abstract class Champion
    {
        public Stats Stats { get; set; }

        public Item[] ItemSlots { get; } = new Item[5];

        public void AddItem(Item item)
        {
            var slotIdx = 0;
            for (slotIdx = 0; slotIdx < ItemSlots.Length; slotIdx++)
                if (ItemSlots[slotIdx] is EmptyItem)
                    break;

            // TODO: check for full inventory
            ItemSlots[slotIdx] = item;
            item.Affect(this.Stats);
        }

        public void RemoveItem(int slot)
        {
            var existingItem = ItemSlots[slot];
            ItemSlots[slot] = Item.Empty;
            existingItem.Unaffect(Stats);
        }
    }
}
