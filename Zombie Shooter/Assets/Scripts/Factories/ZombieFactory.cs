using UnityEngine;
using Zenject;
using ZombieShooter.ZombieEntity;

namespace ZombieShooter.Factories
{
    public class ZombieFactory : IZombieFactory
    {
        [Inject] private DiContainer _container;

        public IZombie Create(Zombie prefab, Vector3 position, Quaternion rotation, Transform parent = null)
        {
          return  _container.InstantiatePrefabForComponent<IZombie>(prefab, position, Quaternion.identity, null);
        }
    }
}
