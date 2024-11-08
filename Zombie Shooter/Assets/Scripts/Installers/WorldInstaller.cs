using UnityEngine;
using Zenject;

namespace ZombieShooter.Installers
{
    public class WorldInstaller : MonoInstaller
    {
        [SerializeField] private World _world;

        public override void InstallBindings()
        {
            Container.Bind<IWorld>().FromInstance(_world).AsSingle().NonLazy();
        }
    }
}