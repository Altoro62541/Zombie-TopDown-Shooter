using System.Collections;
using UnityEngine;
using Zenject;
using ZombieShooter.InputSystem;
using ZombieShooter.TimeSystem;

namespace ZombieShooter.Installers.TimeSystem
{
    public class TimeInstaller : MonoInstaller
    {
        [SerializeField] private TimeHandler _timeHandlerPrefab;
        [SerializeField] private LightProvider _lightProviderPrefab;

        public override void InstallBindings()
        {
            Container.Bind<ILightProvider>().To<LightProvider>().FromNewComponentOnNewPrefab(_lightProviderPrefab).AsSingle().NonLazy();
            Container.Bind<ITimeHandler>().To<TimeHandler>().FromNewComponentOnNewPrefab(_timeHandlerPrefab).AsSingle().NonLazy();
        }
    }
}