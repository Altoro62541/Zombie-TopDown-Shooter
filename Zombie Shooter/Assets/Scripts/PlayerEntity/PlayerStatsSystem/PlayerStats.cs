using System;
using UniRx;
using UnityEngine;

namespace ZombieShooter.PlayerEntity.PlayerStatsSystem
{
    [Serializable]
    public class PlayerStats : IPlayerStats
    {
        [SerializeField] private ReactiveProperty<float> _hungry;
        [SerializeField] private ReactiveProperty<float> _sleep;
        [SerializeField] private ReactiveProperty<float> _reason;
        [SerializeField] private ReactiveProperty<float> _thirst;
        [SerializeField] private ReactiveProperty<float> _warm;

        public ReactiveProperty<float> Hungry => _hungry;
        public ReactiveProperty<float> Sleep => _sleep;
        public ReactiveProperty<float> Reason => _reason;
        public ReactiveProperty<float> Thirst => _thirst;
        public ReactiveProperty<float> Warm => _warm;

        public PlayerStats()
        {
            _sleep = new();
            _reason = new();
            _thirst = new();
            _warm = new();
            _hungry = new();
        }
    }
}
