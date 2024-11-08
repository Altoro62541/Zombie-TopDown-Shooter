using PlayerEntity.PlayerStatsSystem.Handlers;
using UnityEngine;
using Zenject;

namespace ZombieShooter.Installers.PlayerStats
{
    public class PlayerStatsHandlerInstaller : MonoInstaller
    {
        [SerializeField] private PlayerStatsHandler _prefab;

        public override void InstallBindings()
        {
            Container.Bind<IPlayerStatsHandler>().To<PlayerStatsHandler>().FromComponentInNewPrefab(_prefab).AsSingle().NonLazy();
        }
    }
}