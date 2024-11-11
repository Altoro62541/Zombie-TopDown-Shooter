using UnityEngine;
using Zenject;
using ZombieShooter.InventorySystem.WeaponSystem.Handlers;

namespace ZombieShooter.Installers.WeaponSystem
{
    public class WeaponHandlerInstaller : MonoInstaller
    {
        [SerializeField] private WeaponHandler _prefab;

        public override void InstallBindings()
        {
            Container.Bind<IWeaponHandler>().To<WeaponHandler>().FromComponentInNewPrefab(_prefab).AsSingle().NonLazy();
        }
    }
}