using Zenject;
using UnityEngine;
using ZombieShooter.InputSystem;
namespace ZombieShooter.Installers.InputSystem
{
    public class Inputnstaller : MonoInstaller
    {
        [SerializeField] private InputEventHandler _playerInput;
        public override void InstallBindings()
        {
            Container.Bind<IInputEventHandler>().FromInstance(_playerInput).AsSingle().NonLazy();
        }
    }

}