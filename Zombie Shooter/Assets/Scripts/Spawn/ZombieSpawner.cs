using Cysharp.Threading.Tasks;
using System;
using System.Linq;
using UnityEngine;
using Zenject;
using ZombieShooter.Factories;
using ZombieShooter.PlayerEntity;
using ZombieShooter.Spawn.SO;
using ZombieShooter.TimeSystem;
using ZombieShooter.ZombieEntity;
using ZombieShooter.ZombieEntity.SO;
namespace ZombieShooter.Spawn
{
    public class ZombieSpawner : MonoBehaviour
    {
        [Inject] private IZombieFactory _factory;
        [Inject] private IWorld _world;
        [Inject] private IPlayer _player;
        [Inject] private IDayCounterHandler _dayHandler;
        [SerializeField] private ZombieSpawnSettings _spawnSettings;
        [SerializeField] private ZombieSpawnerConfig _spawnConfigs;
        [SerializeField] private Zombie[] _zombies;
        public void Start()
        {
            Spawning().Forget();
            RebuildZombiesArray(); 
        }
        private void OnEnable()
        {
            _dayHandler.OnNewDay += RebuildZombiesArray;
            RebuildZombiesArray(); 
        }
        private void OnDisable()
        {
            _dayHandler.OnNewDay -= RebuildZombiesArray;
        }
        private async UniTask Spawning()
        {
            while (true)
            {
                TimeSpan timeSpan = TimeSpan.FromSeconds(_spawnSettings.RandomTimeSpawn);
                await UniTask.Delay(timeSpan); 

                Vector3 position = _world.GetRandomTilePosition(_player.Position, _spawnSettings.SpawnRadius);
                int randomZombie = UnityEngine.Random.Range(0, _zombies.Length);
                if (position != Vector3.zero)
                {
                    _factory.Create(_zombies[randomZombie], position, Quaternion.identity, null);
                }
            }
        }
        private void RebuildZombiesArray()
        {
        long currentDay = _dayHandler.CurrentDay;
        _zombies = _spawnConfigs.Elements
            .Where(config => config.Day <= currentDay) 
            .Select(config => config.Prefab) 
            .ToArray();
        }

    }
}
