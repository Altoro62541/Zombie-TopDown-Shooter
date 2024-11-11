using System.Collections;
using UnityEngine;
using Zenject;
using ZombieShooter.InventorySystem.SO;
using ZombieShooter.InventorySystem.WeaponSystem.Handlers;

namespace ZombieShooter.InventorySystem.Handlers
{
    public class AggregateStartItems : MonoBehaviour
    {
        [SerializeField] private StartItemsContainer _container;
        [Inject] private IInventoryHandler _handler;
        [Inject] private IWeaponHandler _weaponHandler;

        private async void Start()
        {
            _handler.Add(_container.Items);
           var weapon = await _handler.Add(_container.StartWeapon);
            _weaponHandler.Equip(weapon);
        }
    }
}