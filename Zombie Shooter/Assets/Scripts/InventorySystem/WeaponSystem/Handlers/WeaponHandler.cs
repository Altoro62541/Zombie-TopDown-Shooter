using System;
using System.Collections;
using UniRx;
using UnityEngine;
using Zenject;
using ZombieShooter.InputSystem;
using ZombieShooter.InventorySystem.SO;

namespace ZombieShooter.InventorySystem.WeaponSystem.Handlers
{
    public class WeaponHandler : MonoBehaviour, IWeaponHandler
    {
        private Weapon _activeWeapon;
        private ReactiveCommand<IWeapon> OnEquip = new();
        private ReactiveCommand<IWeapon> OnShoot = new();
        public event Action OnTakeOff;

        [Inject] private IInputEventHandler _input;

        public IWeapon ActiveWeapon => _activeWeapon;

        IReactiveCommand<IWeapon> IWeaponHandler.OnEquip => OnEquip;

        public void Equip(Weapon weapon)
        {
            _activeWeapon = weapon;
            OnEquip?.Execute(weapon);

            Debug.Log($"Equip new Weapon: {_activeWeapon.Name}");
        }

        public void Equip(Item item)
        {
             Weapon newWeapon = new(item);
             Equip(newWeapon);
        }

        public void Equip(WeaponItem weapon)
        {
            Weapon newWeapon = new(weapon);
            Equip(newWeapon);
        }

        private void Shoot()
        {
            _activeWeapon?.Shoot();
        }

        private void Reload()
        {
            _activeWeapon?.TurnReload();
        }

        private void OnEnable()
        {
            _input.OnRightButton += Shoot;
            _input.OnReloadButton += Reload;
        }

        private void OnDisable()
        {
            _input.OnRightButton -= Shoot;
            _input.OnReloadButton -= Reload;
        }
    }
}