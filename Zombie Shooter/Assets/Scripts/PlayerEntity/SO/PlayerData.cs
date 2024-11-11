using Sirenix.OdinInspector;
using System.Collections.Generic;
using UnityEngine;
using ZombieShooter.InventorySystem.WeaponSystem;
using ZombieShooter.PlayerEntity.Models;

namespace ZombieShooter.PlayerEntity.SO
{
    [CreateAssetMenu(menuName = "Player/New Data")]
    public class PlayerData : SerializedScriptableObject
    {
        [SerializeField] private float _health;
        [SerializeField] private float _speedMove;

        [TitleGroup("Sprite States")]
        [SerializeField] private Sprite _noHaveWeaponSprite;
        [SerializeField] private Dictionary<WeaponSpriteVariant, PlayerDataShootState> _statesWeapon;

        public float Health => _health;
        public float SpeedMove => _speedMove;

        public Sprite NoHaveWeaponSprite => _noHaveWeaponSprite;

        public PlayerDataShootState GetState (WeaponSpriteVariant weaponSpriteVariant)
        {
            return _statesWeapon[weaponSpriteVariant];
        }
    }
}