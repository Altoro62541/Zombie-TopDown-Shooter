using System.Collections;
using UnityEngine;
using Zenject;
using ZombieShooter.InventorySystem.SO;

namespace ZombieShooter.InventorySystem.Handlers
{
    public class AggregateStartItems : MonoBehaviour
    {
        [SerializeField] private StartItemsContainer _container;
        [Inject] private IInventoryHandler _handler;

        private void Start()
        {
            _handler.Add(_container.Items);
        }
    }
}