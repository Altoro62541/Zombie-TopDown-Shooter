using Cinemachine;
using UnityEngine;
using Zenject;
using ZombieShooter.PlayerEntity;

namespace ZombieShooter.Spawn
{
    public class PlayerSpawner : MonoBehaviour
    {
        [Inject] private IWorld _world;
        [Inject] private IPlayer _player;
        [SerializeField] private CinemachineVirtualCamera _camera;

        private void Start()
        {
            _player.Transform.position = _world.GetRandomTilePosition();
            _camera.Follow = _player.Transform;
        }
    }
}