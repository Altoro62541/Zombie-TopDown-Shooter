using Sirenix.OdinInspector;
using System.Collections.Generic;
using UnityEngine;

namespace ZombieShooter.TimeSystem.SO
{
    [CreateAssetMenu]
    public class TimeSettings : SerializedScriptableObject
    {
        [SerializeField] private Dictionary<TimeCycleType, TimeCycle> _cycles;

        public TimeCycle GetCycle (TimeCycleType type)
        {
            return _cycles[type];
        }
    }
}