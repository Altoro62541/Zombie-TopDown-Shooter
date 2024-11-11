using System.Collections.Generic;
using UniRx;

namespace ZombieShooter.InventorySystem
{
    public interface IInventory : IEnumerable<Item>
    {
        ISubject<Item> OnAdd { get; }
        ISubject<Item> OnRemove { get; }
        int Count { get; }
        void Add(Item item);
        void Add(IEnumerable<Item> items);
        bool Remove (Item item);
        bool Contains (Item item);
        bool Contains(string guid);
    }
}