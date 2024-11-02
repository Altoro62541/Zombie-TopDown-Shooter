using Zenject;
using UnityEngine;
public class PlayerInstaller : MonoInstaller
{
    [SerializeField] private PlayerInput _playerInput;
    public override void InstallBindings()
    {
        Container.Bind<PlayerInput>().FromInstance(_playerInput).AsSingle().NonLazy();
    }
}
