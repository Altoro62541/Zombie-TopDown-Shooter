using UnityEngine;
using Zenject;
using ZombieShooter.TimeSystem;

namespace ZombieShooter.Installers.TimeSystem
{
    public class LightTimeHandlerInstaller : MonoInstaller
    {
        [SerializeField] private LightTimeHandler _prefab;

        public override void InstallBindings()
        {
            Container.InstantiatePrefab(_prefab);
        }
    }
}