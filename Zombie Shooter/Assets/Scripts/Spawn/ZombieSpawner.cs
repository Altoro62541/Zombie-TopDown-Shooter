using Cysharp.Threading.Tasks;
using System;
using UnityEngine;
using UnityEngine.Tilemaps;
using Zenject;
using ZombieShooter.Factories;
using ZombieShooter.PlayerEntity;
using ZombieShooter.Spawn.SO;
using ZombieShooter.ZombieEntity;

namespace ZombieShooter.Spawn
{
    public class ZombieSpawner : MonoBehaviour
    {
        [Inject] private IZombieFactory _factory;
        [Inject] private IWorld _world;
        [Inject] private IPlayer _player;
        [SerializeField] private Zombie _zombie;
        [SerializeField] private ZombieSpawnSettings _spawnSettings;
        public void Start()
        {
            Spawning().Forget();
        }
        private async UniTask Spawning()
        {
            while (true)
            {
                TimeSpan timeSpan = TimeSpan.FromSeconds(_spawnSettings.RandomTimeSpawn);
                await UniTask.Delay(timeSpan); 

                Vector3 position = _world.GetRandomTilePosition(_player.Position, _spawnSettings.SpawnRadius);

                if (position != Vector3.zero)
                {
                    _factory.Create(_zombie, position, Quaternion.identity, null);
                }
            }
        }

    }
}
