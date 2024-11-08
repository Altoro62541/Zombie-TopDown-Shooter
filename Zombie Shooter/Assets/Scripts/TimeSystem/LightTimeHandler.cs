using System;
using System.Collections;
using UnityEngine;
using Zenject;

namespace ZombieShooter.TimeSystem
{
    public class LightTimeHandler : MonoBehaviour
    {
        [Inject] private ITimeHandler _timeHandler;
        [Inject] private ILightProvider _lightProvider;

        private void Start()
        {
            _lightProvider.TurnCycle(_timeHandler.CurrentCycle.Color, _timeHandler.CurrentCycle.Intensity, 0);
            TurnNextCycle(_timeHandler.NextCycle);
        }

        private void TurnNextCycle (TimeCycle timeCycle)
        {
            var currentCycleStart = _timeHandler.CurrentCycle.StartTime;
            var nextCycleStart = _timeHandler.NextCycle.StartTime;

            TimeSpan duration = currentCycleStart - nextCycleStart;

            double durationInMinutes = duration.TotalMinutes;

            float speed = (float)durationInMinutes;

            if (speed < 0)
            {
                speed *= -1;
            }
            _lightProvider.TurnCycle(timeCycle.Color, timeCycle.Intensity, speed);
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