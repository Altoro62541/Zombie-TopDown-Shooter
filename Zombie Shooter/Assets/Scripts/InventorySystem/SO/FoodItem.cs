using Sirenix.OdinInspector;
using UnityEngine;

namespace ZombieShooter.InventorySystem.SO
{
    public class FoodItem : ScriptableItem
    {
        [SerializeField, MinValue(1)] private float _healing = 5;
        [SerializeField, MinValue(1)] private float _saturation = 15;
        [SerializeField, MinValue(1)] private float _suitability = 150;

        public float Healing => _healing;
        public float Saturation => _saturation;
        public float Suitability => _suitability;

        public override bool TryStack()
        {
            return true;
        }
    }
}
