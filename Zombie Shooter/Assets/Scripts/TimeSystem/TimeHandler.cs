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

        public bool IsLastCurrentCycle => _currentCycleIndex >= _maxCycle;

        private void Awake()
        {
            Initialize();
            Ticking().Forget();

        }

        private void Initialize()
        {
            var allCycles = (TimeCycleType[])Enum.GetValues(typeof(TimeCycleType));

            _maxCycle = allCycles.Length;
            _startCycleIndex = (int)allCycles[0];
            _endCycleIndex = allCycles.IndexOf(TimeCycleType.Night) + 1;
            _currentCycleIndex = _startCycleIndex;
            _currentTime = new();
            _currentCycle = _timeSettings.GetCycle(_currentCycleIndex);
            _currentTime = _currentTime.AddHours(_currentCycle.Hour);
            _tick = TimeSpan.FromSeconds(_timeSettings.TickMinutes);
            _nextCycleIndex = Mathf.Clamp(_currentCycleIndex + 1, 0, _maxCycle);
            _nextCycle = _timeSettings.GetCycle(_nextCycleIndex);
        }

        private void TurnNextCycle ()
        {
            _currentCycleIndex = Mathf.Clamp(_currentCycleIndex + 1, 0, _maxCycle);
            if (_currentCycleIndex >= _maxCycle)
            {
                _currentCycleIndex = _endCycleIndex;
                _nextCycleIndex = _startCycleIndex;
                OnRestartCycle?.Invoke();
            }

            else
            {
                _nextCycleIndex = _currentCycleIndex + 1;
            }
            _currentCycle = _timeSettings.GetCycle(_currentCycleIndex);
            _nextCycle = _timeSettings.GetCycle(_nextCycleIndex);
            OnNewCycle?.Invoke(_nextCycle);
        }

        private async UniTask Ticking ()
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