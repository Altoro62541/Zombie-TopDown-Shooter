using System;
using UnityEngine;
using Zenject;
using ZombieShooter.TimeSystem.SO;
using System.Linq;
using Cysharp.Threading.Tasks;
namespace ZombieShooter.TimeSystem
{
    public class TimeHandler : MonoBehaviour, ITimeHandler
    {
        [SerializeField] private TimeSettings _timeSettings;
        [Inject] private ILightProvider _lightProvider;

        private int _currentCycleIndex;
        private int _maxCycle;

        private DateTime _currentTime;
        private TimeSpan _tick;

        private TimeCycle _currentCycle;

        public string Time => _currentTime.ToString("HH:mm");

        private void Awake()
        {
            Initialize();
            Ticking().Forget();

        }

        private void Initialize()
        {
            var allCycles = (TimeCycleType[])Enum.GetValues(typeof(TimeCycleType));

            _maxCycle = allCycles.Length;
            _currentCycleIndex = (int)allCycles[0];
            _currentTime = new();
            _currentCycle = _timeSettings.GetCycle(_currentCycleIndex);
            _currentTime = _currentTime.AddHours(_currentCycle.Hour);
            _tick = TimeSpan.FromSeconds(_timeSettings.TickMinutes);
        }

        private async UniTask Ticking ()
        {
            while (true)
            {
                await UniTask.Delay(_tick);
                _currentTime = _currentTime.AddMinutes(_timeSettings.MinutesPerTick);
                Debug.Log(Time);
            }
        }
    }
}