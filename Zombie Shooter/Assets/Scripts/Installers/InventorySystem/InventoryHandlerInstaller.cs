using UnityEngine;
using Zenject;
using ZombieShooter.InventorySystem.Handlers;

namespace ZombieShooter.Installers.InventorySystem
{
    public class InventoryHandlerInstaller : MonoInstaller
    {
        [SerializeField] private InventoryHandler _prefab;

        public override void InstallBindings()
        {
            Container.Bind<IInventoryHandler>().To<InventoryHandler>().FromComponentInNewPrefab(_prefab).AsSingle().NonLazy();
        }
    }
}