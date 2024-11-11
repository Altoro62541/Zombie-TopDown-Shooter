using Sirenix.OdinInspector;
using UnityEngine;

namespace ZombieShooter.InventorySystem.SO
{
    [CreateAssetMenu(menuName = "Inventory/Items/Weapon")]
    public class WeaponItem : ScriptableItem
    {
        [SerializeField, MinValue(1)] private int ammunition = 10;
        [SerializeField, MinValue(0)] private float _speedShoot;
        [SerializeField, MinValue(0.1f)] private float _speedReload = 0.5f;
        [SerializeField, MinValue(1)] private float _strength = 6;
        [SerializeField, MinValue(1)] private float _lowStrengthPerShoot = 1;
        [SerializeField, MinValue(1)] private float _damage = 1;

        public int Ammunition => ammunition;
        public float SpeedShoot => _speedShoot;
        public float SpeedReload => _speedReload;
        public float Strength => _strength;
        public float LowStrengthPerShoot => _lowStrengthPerShoot;
        public float Damage => _damage;

        public override bool TryStack()
        {
            return false;
        }
    }
}
