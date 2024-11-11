using Cysharp.Threading.Tasks;
using System.Collections.Generic;
using UnityEngine.AddressableAssets;
using ZombieShooter.InventorySystem.SO;

namespace ZombieShooter.InventorySystem.Handlers
{
    public interface IScriptableItemLoader
    {
        UniTask<T> LoadScriptableItemAsync<T>(string guid) where T : ScriptableItem;
        UniTask<T> LoadScriptableItemAsync<T>(AssetReferenceT<ScriptableItem> assetReference) where T : ScriptableItem;
        UniTask<IEnumerable<T>> LoadScriptableItemsAsync<T>(IEnumerable<AssetReferenceT<ScriptableItem>> assetReferences) where T : ScriptableItem;

       void ReleaseScriptableItemAsync<T>(T item) where T : ScriptableItem;
        void ReleaseScriptableItemsAsync<T>(IEnumerable<T> items) where T : ScriptableItem;
    }
}