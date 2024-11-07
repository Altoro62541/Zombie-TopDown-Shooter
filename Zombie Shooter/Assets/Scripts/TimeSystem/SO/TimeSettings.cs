using Sirenix.OdinInspector;
using System.Collections.Generic;
using UnityEngine;

namespace ZombieShooter.TimeSystem.SO
{
    [CreateAssetMenu]
    public class TimeSettings : SerializedScriptableObject
    {
        [SerializeField] private Dictionary<TimeCycleType, TimeCycle> _cycles;
        [SerializeField, MinValue(1)] private float _tickMinutes = 1;
        [SerializeField, MinValue(1)] private float _minutesPerTick = 1;

        public float TickMinutes => _minutesPerTick;
        public float MinutesPerTick => _minutesPerTick;

        public TimeCycle GetCycle (int index)
        {
            TimeCycleType type = (TimeCycleType)index;
            return _cycles[type];
        }
    }
}