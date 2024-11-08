using UnityEngine;
using Zenject;
using ZombieShooter.PlayerEntity;
using Cinemachine;
using ZombieShooter.Factories;

namespace ZombieShooter.Installers.PlayerEntity
{
    public class PlayerInstaller : MonoInstaller
    {   
        [SerializeField] private Player _prefab;
        [Inject] private IPlayerFactory _factory;
        [Inject] private IWorld _world;

        public override void InstallBindings()
        {
            var player = _factory.Create(_prefab, Vector3.zero, Quaternion.identity) as Player;
            Container.Bind<IPlayer>().To<Player>().FromComponentOn(player.gameObject).AsSingle().NonLazy();
        }
    }
}
