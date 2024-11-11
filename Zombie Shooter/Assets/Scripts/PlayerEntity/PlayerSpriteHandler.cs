using System;
using System.Collections;
using UniRx;
using UnityEngine;
using Zenject;
using ZombieShooter.InventorySystem.WeaponSystem;
using ZombieShooter.InventorySystem.WeaponSystem.Handlers;

namespace ZombieShooter.PlayerEntity
{
    public class PlayerSpriteHandler : MonoBehaviour
    {
        private SpriteRenderer _spriteRenderer;
        private IPlayer _player;
        [Inject] private IWeaponHandler _weaponHandler;
        private CompositeDisposable _disposable = new();
        private IWeapon _currentWeapon;

        private void Awake()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _player = GetComponent<IPlayer>();
        }

        private void OnEquip(IWeapon weapon)
        {
            if (_currentWeapon != null)
            {
                _currentWeapon.OnReload -= OnReload;
                _currentWeapon.OnReloadFinish -= OnReloadFinish;
            }

            _currentWeapon = weapon;
            _currentWeapon.OnReload += OnReload;
            _currentWeapon.OnReloadFinish += OnReloadFinish;
            SetSprite(_player.Data.GetState(weapon.SpriteVariant).Active);
        }

        private void OnReloadFinish()
        {
            SetSprite(_player.Data.GetState(_currentWeapon.SpriteVariant).Active);
        }

        private void OnReload()
        {
            SetSprite(_player.Data.GetState(_currentWeapon.SpriteVariant).Reloading);
        }

        private void SetSprite (Sprite sprite)
        {
            _spriteRenderer.sprite = sprite;
        }

        private void OnEnable()
        {
            _weaponHandler.OnEquip.Subscribe(weapon => {
                OnEquip(weapon);
            }).AddTo(_disposable);
        }

        private void OnDisable()
        {
            if (_currentWeapon != null)
            {
                _currentWeapon.OnReload -= OnReload;
                _currentWeapon.OnReloadFinish -= OnReloadFinish;
            }

            _disposable.Clear();
        }
    }
}