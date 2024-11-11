using System;
using UnityEngine;

namespace ZombieShooter.InventorySystem.WeaponSystem
{
    public interface IWeapon : IIdentity
    {
        event Action OnReload;
        event Action OnReloadFinish;
        event Action OnShoot;
        WeaponSpriteVariant SpriteVariant { get; }
        int CurrentAmmunition { get; }
        public float SpeedShoot { get; }
        public float SpeedReload { get; }
        public float Strength { get; }
        public float LowStrengthPerShoot { get; }
        public float Damage { get; }
        public Sprite Icon { get; }
        public string Name { get; }
        public string Description { get; }
    }
}