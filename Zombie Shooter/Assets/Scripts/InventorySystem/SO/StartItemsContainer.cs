using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace ZombieShooter.InventorySystem.SO
{
    [CreateAssetMenu(menuName = "Inventory/Start Items")]
    public class StartItemsContainer : ScriptableObject
    {
        [SerializeField] private List<AssetReferenceT<ScriptableItem>> _items;
        [SerializeField] private AssetReferenceT<ScriptableItem> _startWeapon;

        public IEnumerable<AssetReferenceT<ScriptableItem>> Items => _items;

        public AssetReferenceT<ScriptableItem> StartWeapon => _startWeapon;
    }
}