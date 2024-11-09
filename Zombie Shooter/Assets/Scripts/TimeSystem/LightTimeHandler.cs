using System;
using System.Collections;
using UnityEngine;
using Zenject;
using ZombieShooter.TimeSystem.SO;

namespace ZombieShooter.TimeSystem
{
    public class LightTimeHandler : MonoBehaviour
    {
        [Inject] private ITimeHandler _timeHandler;
        [Inject] private ILightProvider _lightProvider;
        [SerializeField] private TimeSettings _timeSettings;

        private void Start()
        {
            _lightProvider.TurnCycle(_timeHandler.CurrentCycle.Color, _timeHandler.CurrentCycle.Intensity, 0);
            TurnNextCycle(_timeHandler.NextCycle);
        }

        private void TurnNextCycle(TimeCycle timeCycle)
        {
            var currentCycleStart = _timeHandler.CurrentCycle.StartTime;
            var nextCycleStart = _timeHandler.NextCycle.StartTime;

            if (nextCycleStart < currentCycleStart)
            {
                nextCycleStart = nextCycleStart.AddDays(1);
            }

            var span = nextCycleStart - currentCycleStart;
            int totalSeconds = (int)span.TotalSeconds;
            float tickDurationInSeconds = _timeSettings.MinutesPerTick * 60 / _timeSettings.TickMinutes;

            float tickCount = totalSeconds / tickDurationInSeconds;

            if (tickCount < 0)
            {
                tickCount *= -1;
            }
            _lightProvider.TurnCycle(timeCycle.Color, timeCycle.Intensity, tickCount);
        }

        private void OnEnable()
        {
            _timeHandler.OnNewCycle += TurnNextCycle;
        }

        private void OnDisable()
        {
            _timeHandler.OnNewCycle -= TurnNextCycle;
        }
    }
}