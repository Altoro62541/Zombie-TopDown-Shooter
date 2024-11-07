using UnityEngine;
using UnityEngine.Tilemaps;
using Zenject;
using ZombieShooter.PlayerEntity;
using Cinemachine;

namespace ZombieShooter.Installers.PlayerEntity
{
    public class PlayerInstaller : MonoInstaller
    {   
    [SerializeField] private Tilemap _tilemap;
    [SerializeField] private Player _player;
    [SerializeField] private CinemachineVirtualCamera _camera;
    [SerializeField] private LayerMask _obstacleLayer; // Слой для коллайдеров

    public override void InstallBindings()
    {       
        var player = Container.InstantiatePrefabForComponent<Player>(_player);
        player.transform.position = GetRandomTilePosition();
        Container.Bind<IPlayer>().To<Player>().FromInstance(player).AsSingle().NonLazy();
        _camera.Follow = player.transform;
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

                // Проверка на наличие коллайдера
                if (!Physics2D.OverlapPoint(worldPosition, _obstacleLayer))
                {
                    return worldPosition;
                }
            }
        }

        Debug.LogWarning("No suitable tile found!");
        return Vector3.zero;
    }
    }
}
