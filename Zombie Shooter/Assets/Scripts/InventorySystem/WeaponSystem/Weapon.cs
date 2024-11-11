using Cysharp.Threading.Tasks;
using System;
using UnityEngine;
using ZombieShooter.InventorySystem.SO;

namespace ZombieShooter.InventorySystem.WeaponSystem
{
    [Serializable]
    public class Weapon : IIdentity, IWeapon
    {
        public event Action OnReload;
        public event Action OnReloadFinish;
        public event Action OnShoot;
        private WeaponSpriteVariant _spriteVariant;
        private Sprite _icon;
        private string _name;
        private string _description;
        private int _ammunitionBank;
        private int _currentAmmunition;
        private float _speedShoot;
        private float _speedReload;
        private float _strength;
        private float _lowStrengthPerShoot;
        private float _damage;
        private string _guidItem;
        private bool _isReload;

        public int AmmunitionBank => _ammunitionBank;
        public int CurrentAmmunition { get => _currentAmmunition; set => _currentAmmunition = value; }
        public float SpeedShoot { get => _speedShoot; set => _speedShoot = value; }
        public float SpeedReload { get => _speedReload; set => _speedReload = value; }
        public float Strength { get => _strength; set => _strength = value; }
        public float LowStrengthPerShoot { get => _lowStrengthPerShoot; set => _lowStrengthPerShoot = value; }
        public float Damage { get => _damage; set => _damage = value; }
        public Sprite Icon => _icon;
        public string Name => _name;
        public string Description => _description;

        public string GUID => _guidItem;

        public WeaponSpriteVariant SpriteVariant => _spriteVariant;

        public Weapon(Item item)
        {
            if (item.Reference is WeaponItem weaponItem == false)
            {
                throw new ArgumentException($"item {item.Reference.Name} not have type {typeof(WeaponItem)}");
            }
            if (weaponItem is null)
            {
                throw new ArgumentNullException(nameof(weaponItem));
            }
            _spriteVariant = weaponItem.SpriteVariant;
            _icon = weaponItem.Icon;
            _name = weaponItem.Name;
            _description = weaponItem.Description;
            _name = weaponItem.Name;
            _strength = weaponItem.Strength;
            _lowStrengthPerShoot = weaponItem.LowStrengthPerShoot;
            _damage = weaponItem.Damage;
            _currentAmmunition = weaponItem.Ammunition;
            _speedReload = weaponItem.SpeedReload;
            _speedShoot = weaponItem.SpeedShoot;
            _guidItem = weaponItem.GUID;
        }

        public Weapon(WeaponItem weaponItem)
        {
            if (weaponItem is null)
            {
                throw new ArgumentNullException(nameof(weaponItem));
            }

            _spriteVariant = weaponItem.SpriteVariant;
            _icon = weaponItem.Icon;
            _name = weaponItem.Name;
            _description = weaponItem.Description;
            _name = weaponItem.Name;
            _strength = weaponItem.Strength;
            _lowStrengthPerShoot = weaponItem.LowStrengthPerShoot;
            _damage = weaponItem.Damage;
            _currentAmmunition = weaponItem.Ammunition;
            _speedReload = weaponItem.SpeedReload;
            _speedShoot = weaponItem.SpeedShoot;
            _guidItem = weaponItem.GUID;
        }

        public void TurnReload ()
        {
            if (_isReload)
            {
                return;
            }

            Reload().Forget();
        }

        public void Shoot()
        {
            if (_currentAmmunition > 0)
            {
                _currentAmmunition--;
            }
        }

        private async UniTask Reload ()
        {
            OnReload?.Invoke();
            TimeSpan span = TimeSpan.FromSeconds(_speedReload);
            await UniTask.Delay(span);
            _currentAmmunition = _ammunitionBank;
            _isReload = false;
            OnReloadFinish?.Invoke();

        }


    }
}
