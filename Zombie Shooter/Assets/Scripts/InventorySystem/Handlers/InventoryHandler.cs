using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using Zenject;
using ZombieShooter.InventorySystem.SO;

namespace ZombieShooter.InventorySystem.Handlers
{
    public class InventoryHandler : MonoBehaviour, IInventoryHandler
    {
        private Inventory _inventory;

        [Inject] private IScriptableItemLoader _itemLoader;

        public IEnumerable<Item> Inventory => _inventory;

        private void Awake()
        {
            _inventory = new();
        }

        public async UniTask<Item> Add(AssetReferenceT<ScriptableItem> asset)
        {
            var itemReference = await _itemLoader.LoadScriptableItemAsync<ScriptableItem>(asset);
            Item item = new(itemReference);
            _inventory.Add(item);
            return item;
        }

        public async void Add(IEnumerable<AssetReferenceT<ScriptableItem>> assets)
        {
            var itemReferences = await _itemLoader.LoadScriptableItemsAsync<ScriptableItem>(assets);

            foreach (var reference in itemReferences)
            {
                Item item = new(reference);
                _inventory.Add(item);
            }
        }

        public bool Remove(Item item)
        {
            return _inventory.Remove(item);
        }

        public bool Contains (ScriptableItem item)
        {
            return _inventory.Contains(item.GUID);
        }

        public bool Contains(Item item)
        {
            return _inventory.Contains(item);
        }
    }
}