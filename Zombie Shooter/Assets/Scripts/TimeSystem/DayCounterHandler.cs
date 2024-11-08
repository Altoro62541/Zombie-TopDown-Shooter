using System;
using UnityEngine;
using Zenject;

namespace ZombieShooter.TimeSystem
{
    public class DayCounterHandler : MonoBehaviour, IDayCounterHandler
    {
        [Inject] private ITimeHandler _timeHandler;
        public event Action OnNewDay;
        public long CurrentDay { get; private set; } = 1;

        private void IncrementDay()
        {
            CurrentDay++;
            OnNewDay?.Invoke();
            Debug.Log($"New Day: day {CurrentDay}");
        }
        private void OnEnable()
        {
            _timeHandler.OnRestartCycle += IncrementDay;
        }
        private void OnDisable()
        {
            _timeHandler.OnRestartCycle -= IncrementDay;
        }
    }
    }