using Sirenix.OdinInspector;
using System.Collections.Generic;
using UnityEngine;

namespace ZombieShooter.TimeSystem.SO
{
    [CreateAssetMenu]
    public class TimeSettings : SerializedScriptableObject
    {
        [SerializeField] private Dictionary<TimeCycleType, TimeCycle> _cycles;
        [SerializeField, MinValue(0.1f)] private float _tickMinutes = 1;
        [SerializeField, MinValue(1)] private float _minutesPerTick = 1;

        public float TickMinutes => _tickMinutes;
        public float MinutesPerTick => _minutesPerTick;

        public TimeCycle GetCycle (int index)
        {
            TimeCycleType type = (TimeCycleType)index;
            return _cycles[type];
        }
    }
}