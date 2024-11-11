using System.Collections.Generic;

namespace ZombieShooter.InventorySystem
{
    public interface IInventory : IEnumerable<Item>
    {
        int Count { get; }
        void Add(Item item);
        void Add(IEnumerable<Item> items);
        bool Remove (Item item);
        bool Contains (Item item);
        bool Contains(string guid);
    }
}