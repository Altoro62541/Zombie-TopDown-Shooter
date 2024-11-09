using System;
using UniRx;
using UnityEngine;

namespace ZombieShooter.PlayerEntity.PlayerStatsSystem
{
    [Serializable]
    public class PlayerStats : IPlayerStats
    {
        [SerializeField] private FloatReactiveProperty _hungry;
        [SerializeField] private FloatReactiveProperty _sleep;
        [SerializeField] private FloatReactiveProperty _mentai;
        [SerializeField] private FloatReactiveProperty _thirst;
        [SerializeField] private FloatReactiveProperty _warm;

        public FloatReactiveProperty Hungry => _hungry;
        public FloatReactiveProperty Sleep => _sleep;
        public FloatReactiveProperty Mentai => _mentai;
        public FloatReactiveProperty Thirst => _thirst;
        public FloatReactiveProperty Warm => _warm;

        public PlayerStats()
        {
            _sleep = new();
            _mentai = new();
            _thirst = new();
            _warm = new();
            _hungry = new();
        }
    }
}
