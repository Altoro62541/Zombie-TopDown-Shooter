using System;
using UnityEngine;
using ZombieShooter.TimeSystem.SO;
using Cysharp.Threading.Tasks;
using ModestTree;
namespace ZombieShooter.TimeSystem
{
    public class TimeHandler : MonoBehaviour, ITimeHandler
    {
        public event Action OnTick;
        public event Action<TimeCycle> OnNewCycle;
        public event Action OnRestartCycle;
        [SerializeField] private TimeSettings _timeSettings;

        private int _currentCycleIndex;
        private int _nextCycleIndex;
        private int _maxCycle;
        private int _startCycleIndex;
        private int _endCycleIndex;

        public DateTime _currentTime;
        private TimeSpan _tick;

        private TimeCycle _currentCycle;
        private TimeCycle _nextCycle;

        public string Time => _currentTime.ToString("HH:mm");

        public TimeCycle CurrentCycle => _currentCycle;
        public TimeCycle NextCycle => _nextCycle;

        public bool IsLastCurrentCycle => _nextCycleIndex == _startCycleIndex;

        private void Awake()
        {
            Initialize();
            Ticking().Forget();

        }

        private void Initialize()
        {
            var allCycles = (TimeCycleType[])Enum.GetValues(typeof(TimeCycleType));

            _maxCycle = allCycles.Length;
            _startCycleIndex = allCycles.IndexOf(TimeCycleType.Morming);
            _endCycleIndex = allCycles.IndexOf(TimeCycleType.Night);
            _currentCycleIndex = _startCycleIndex;
            _currentTime = new();
            _currentCycle = _timeSettings.GetCycle(_currentCycleIndex);
            _currentTime = _currentTime.AddHours(_currentCycle.Hour);
            _tick = TimeSpan.FromSeconds(_timeSettings.TickMinutes);
            _nextCycleIndex = _currentCycleIndex + 1;
            _nextCycle = _timeSettings.GetCycle(_nextCycleIndex);
        }

        private void TurnNextCycle()
        {
            _currentCycleIndex = (_currentCycleIndex + 1) % (_endCycleIndex + 1); // Cycle wrapping

            if (_currentCycleIndex == _endCycleIndex)
            {
                OnRestartCycle?.Invoke();
            }
            _nextCycleIndex = (_currentCycleIndex + 1) % (_endCycleIndex + 1); // Cycle wrapping
            _currentCycle = _timeSettings.GetCycle(_currentCycleIndex);
            _nextCycle = _timeSettings.GetCycle(_nextCycleIndex);
            OnNewCycle?.Invoke(_nextCycle);
        }

        private async UniTask Ticking()
        {
            while (true)
            {
                await UniTask.Delay(_tick);
                _currentTime = _currentTime.AddMinutes(_timeSettings.MinutesPerTick);
                OnTick?.Invoke();

                if (_currentTime.Hour == _nextCycle.Hour)
                {
                    TurnNextCycle();
                }
            }
        }
    }
}
