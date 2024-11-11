using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using ZombieShooter.InventorySystem.SO;

namespace ZombieShooter.InventorySystem.Handlers
{
    public class ScriptableItemLoader : MonoBehaviour, IScriptableItemLoader
    {
        public async UniTask<T> LoadScriptableItemAsync<T>(string guid) where T : ScriptableItem
        {
            AsyncOperationHandle<ScriptableItem> handle = Addressables.LoadAssetAsync<ScriptableItem>(guid);
            await handle.ToUniTask();
            if (handle.Status == AsyncOperationStatus.Succeeded)
            {
                return handle.Result as T;
            }
            else
            {
                Debug.LogError($"Ошибка загрузки ScriptableItem по GUID: {guid}");
                return null;
            }
        }
        public async UniTask<T> LoadScriptableItemAsync<T>(AssetReferenceT<ScriptableItem> assetReference) where T : ScriptableItem
        {
            AsyncOperationHandle<ScriptableItem> handle = assetReference.LoadAssetAsync<ScriptableItem>();
            await handle.ToUniTask();
            if (handle.Status == AsyncOperationStatus.Succeeded)
            {
                return handle.Result as T;
            }
            else
            {
                Debug.LogError($"Ошибка загрузки ScriptableItem по AddressablesReference: {assetReference.AssetGUID}");
                return null;
            }
        }

        public async UniTask<IEnumerable<T>> LoadScriptableItemsAsync<T>(IEnumerable<AssetReferenceT<ScriptableItem>> assetReferences) where T : ScriptableItem
        {
            List<T> result = new();
            foreach (var item in assetReferences)
            {
             T reference = await LoadScriptableItemAsync<T>(item);
             result.Add(reference);
            }

            return result;
        }

        // Очистка памяти
        public void ReleaseScriptableItemAsync<T>(T item) where T : ScriptableItem
        {
            if (item is null)
            {
                return;
            }
            Addressables.Release(item);
        }
        public void ReleaseScriptableItemsAsync<T>(IEnumerable<T> items) where T : ScriptableItem
        {
            if (items is null || items.Count() == 0)
            {
                return;
            }
            foreach (T item in items)
            {
                ReleaseScriptableItemAsync(item);
            }
        }
    }
}