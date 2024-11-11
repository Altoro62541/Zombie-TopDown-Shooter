using System.Collections.Generic;

namespace ZombieShooter.InventorySystem
{
    public interface IInventory : IEnumerable<Item>
    {
        int Count { get; }
        void Add(Item item);
        bool Remove (Item item);
        bool Contains (Item item);
    }
}