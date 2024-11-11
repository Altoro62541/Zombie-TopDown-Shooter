using UnityEngine;
using Zenject;
using ZombieShooter.InventorySystem.Handlers;

namespace ZombieShooter.Installers.InventorySystem
{
    public class ScriptableItemLoaderInstaller : MonoInstaller
    {
        [SerializeField] private ScriptableItemLoader _prefab;

        public override void InstallBindings()
        {
            Container.Bind<IScriptableItemLoader>().To<ScriptableItemLoader>().FromComponentInNewPrefab(_prefab).AsSingle().NonLazy();
        }
    }
}