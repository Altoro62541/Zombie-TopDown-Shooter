using UnityEngine;
using UnityEngine.Tilemaps;

namespace ZombieShooter
{
    [RequireComponent(typeof(Tilemap))]
    public class World : MonoBehaviour, IWorld
    {
        private Tilemap _tilemap;
        [SerializeField] private LayerMask _obstacleLayer;
        private void Awake()
        {
            _tilemap = GetComponent<Tilemap>();
        }
        public Vector3 GetRandomTilePosition(Vector3? center = null, float radius = float.MaxValue)
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
                    if (center.HasValue && Vector3.Distance(worldPosition, center.Value) > radius)
                    {
                        continue;
                    }

                    if (!Physics2D.OverlapPoint(worldPosition, _obstacleLayer))
                    {
                        return worldPosition;
                    }
                }
            }

            Debug.LogWarning($"No suitable tile found{(center.HasValue ? $" within the specified radius" : string.Empty)}!");
            return Vector3.zero;
        }


    }
}