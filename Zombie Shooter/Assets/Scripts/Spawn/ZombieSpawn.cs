using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.Tilemaps;
using Zenject;
using ZombieShooter.ZombieEntity;

namespace ZombieShooter.Spawn
{
    public class ZombieSpawn : MonoBehaviour
    {
        [Inject] private DiContainer _container;
        [SerializeField] private Zombie _zombie;
        [SerializeField] private Tilemap _tilemap;
        [SerializeField] private LayerMask _obstacleLayer;
        [SerializeField] private Transform _player; 
        [SerializeField] private float _spawnRadius = 5f; 
        public void Start()
        {
            Spawning().Forget();
        }
            
        public Vector3 GetRandomTilePosition()
    {
        BoundsInt bounds = _tilemap.cellBounds;

        for (int i = 0; i < 100; i++)
        {
            int x = Random.Range(bounds.xMin, bounds.xMax);
            int y = Random.Range(bounds.yMin, bounds.yMax);
            Vector3Int randomPosition = new Vector3Int(x, y, 0);

            if (_tilemap.HasTile(randomPosition))
            {
                Vector3 worldPosition = _tilemap.CellToWorld(randomPosition) + _tilemap.cellSize / 2;

                
                if (!Physics2D.OverlapPoint(worldPosition, _obstacleLayer) && 
                    Vector3.Distance(worldPosition, _player.position) <= _spawnRadius)
                {
                    return worldPosition;
                }
            }
        }

        Debug.LogWarning("No suitable tile found!");
        return Vector3.zero;
    }
        private async UniTask Spawning()
        {
            while (true)
            {
                await UniTask.Delay(3000); 

                Vector3 position = GetRandomTilePosition();

                if (position != Vector3.zero)
                {
                    _container.InstantiatePrefab(_zombie, position, Quaternion.identity, null);
                }
            }
        }

    }
}
