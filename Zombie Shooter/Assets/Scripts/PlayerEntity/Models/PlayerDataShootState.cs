using Sirenix.OdinInspector;
using System;
using UnityEngine;
namespace ZombieShooter.PlayerEntity.Models
{
    [Serializable]
    public class PlayerDataShootState
    {
        [SerializeField, PreviewField] private Sprite _active;
        [SerializeField, PreviewField] private Sprite _reloading;

        public Sprite Active => _active;
        public Sprite Reloading => _reloading;
    }
}
