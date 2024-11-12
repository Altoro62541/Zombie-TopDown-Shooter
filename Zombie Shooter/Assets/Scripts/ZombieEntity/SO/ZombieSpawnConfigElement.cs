using System;
using UnityEngine;
using ZombieShooter.TimeSystem;

namespace ZombieShooter.ZombieEntity.SO
{
    [Serializable]
    public class ZombieSpawnConfigElement
    {
        [SerializeField] private int _day;
        [SerializeField] private Zombie _prefab;
        [SerializeField] private IDayCounterHandler _dayHandler;
        private Zombie[] _zombies;
        public int Day => _day;
        public Zombie Prefab => _prefab;

    }
}

