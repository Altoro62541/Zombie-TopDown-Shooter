using Zenject;
using UnityEngine;
namespace ZombieShooter.Installers.Player
{
    public class PlayerInstaller : MonoInstaller
    {
        [SerializeField] private InputEventHandler _playerInput;
        public override void InstallBindings()
        {
            Container.Bind<InputEventHandler>().FromInstance(_playerInput).AsSingle().NonLazy();
        }
    }

}