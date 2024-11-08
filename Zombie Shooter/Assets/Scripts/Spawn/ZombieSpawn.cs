using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.Tilemaps;
using Zenject;
using ZombieShooter.Factories;
using ZombieShooter.ZombieEntity;

namespace ZombieShooter.Spawn
{
    public class ZombieSpawn : MonoBehaviour
    {
        [Inject] private IZombieFactory _factory;
        [Inject] private IWorld _world;
        [SerializeField] private Zombie _zombie;
        [SerializeField] private Tilemap _tilemap;
        [SerializeField] private Transform _player; 
        [SerializeField] private float _spawnRadius = 5f; 
        public void Start()
        {
            Spawning().Forget();
        }
        private async UniTask Spawning()
        {
            while (true)
            {
                await UniTask.Delay(3000); 

                Vector3 position = _world.GetRandomTilePosition();

                if (position != Vector3.zero)
                {
                    _factory.Create(_zombie, position, Quaternion.identity, null);
                }
            }
        }

    }
}
