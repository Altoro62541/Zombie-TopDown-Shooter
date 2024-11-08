using System;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

namespace ZombieShooter.UI.Installers
{
    public class EventSystemInstaller : MonoInstaller
    {

        [SerializeField] private EventSystem _prefab;

        public override void InstallBindings()
        {
            if (!_prefab)
            {
                throw new NullReferenceException("event system prefab are not assigned");
            }

            var prefab = Container.InstantiatePrefabForComponent<EventSystem>(_prefab);

            Container.Bind<EventSystem>().FromInstance(prefab);
        }
    }
}