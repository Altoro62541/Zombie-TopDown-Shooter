using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace ZombieShooter.InventorySystem.SO
{
    [CreateAssetMenu(menuName = "Inventory/Start Items")]
    public class StartItemsContainer : ScriptableObject
    {
        [SerializeField] private List<AssetReferenceT<ScriptableItem>> _items;

        public IEnumerable<AssetReferenceT<ScriptableItem>> Items => _items;
    }
}