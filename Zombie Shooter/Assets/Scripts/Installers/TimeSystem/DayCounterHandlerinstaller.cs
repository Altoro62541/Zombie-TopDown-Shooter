using UnityEngine;
using Zenject;
using ZombieShooter.TimeSystem;

namespace Installers.TimeSystem
{
    public class DayCounterHandlerinstaller : MonoInstaller
    {
        [SerializeField] private DayCounterHandler _prefab;

        public override void InstallBindings()
        {
            Container.Bind<IDayCounterHandler>().To<DayCounterHandler>().FromComponentInNewPrefab(_prefab).AsSingle().NonLazy();
        }
    }
}