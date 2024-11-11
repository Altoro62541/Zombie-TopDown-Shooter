using UniRx;
using UnityEngine;
using Zenject;
using ZombieShooter.Factories;
using ZombieShooter.InventorySystem.WeaponSystem;
using ZombieShooter.InventorySystem.WeaponSystem.Handlers;

namespace ZombieShooter.PlayerEntity
{
    public class PlayerShootPoint : MonoBehaviour
    {
        private CompositeDisposable _disposable = new();
        private IWeapon _currentWeapon;
        private IPlayer _player;
        [SerializeField] private Transform _point;
        [SerializeField] private Bullet _bulletPrefab;
        [Inject] private IWeaponHandler _weaponHandler;
        [Inject] private IBulletFactory _bulletFactory;
        private void Awake()
        {
            _player = GetComponent<Player>();
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
                _currentWeapon.OnShoot -= OnShoot;
            }

            _disposable.Clear();
        }

        private void OnEquip(IWeapon weapon)
        {
            if (_currentWeapon != null)
            {
                _currentWeapon.OnShoot -= OnShoot;
            }

            _currentWeapon = weapon;
            _currentWeapon.OnShoot += OnShoot;
        }

        private void OnShoot()
        {
          var bullet =  _bulletFactory.Create(_bulletPrefab, _point.position, _point.rotation);
            bullet.SetData(new(_currentWeapon.Damage, 100));
        }
    }
}