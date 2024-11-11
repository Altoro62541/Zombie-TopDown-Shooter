using SiphoinUnityHelpers.Polling;
using UnityEngine;
using Zenject;
using ZombieShooter.InventorySystem.WeaponSystem;

namespace ZombieShooter.Factories
{
    public class BulletFactory : IBulletFactory
    {
        [Inject] private DiContainer _container;
        private PoolMono<Bullet> _pool;
        public IBullet Create(Bullet prefab, Vector3 position, Quaternion rotation, Transform parent = null)
        {
            if (_pool is null)
            {
                _pool = new(prefab, 30, true);
            }
            var bullet = _pool.GetFreeElement();
            bullet.transform.position = position;
            bullet.transform.rotation = rotation;
            return bullet;
        }
    }
}
