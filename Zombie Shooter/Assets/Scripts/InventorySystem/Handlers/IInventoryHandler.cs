using System.Collections.Generic;
using UnityEngine.AddressableAssets;
using ZombieShooter.InventorySystem.SO;

namespace ZombieShooter.InventorySystem.Handlers
{
    public interface IInventoryHandler
    {
        IEnumerable<Item> Inventory { get; }
        void Add(AssetReferenceT<ScriptableItem> asset);
        void Add(IEnumerable<AssetReferenceT<ScriptableItem>> assets);
        bool Remove(Item item);
        bool Contains(Item item);
        bool Contains(ScriptableItem item);

    }
}