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

            // Вычисляем продолжительность между циклами
            TimeSpan duration = currentCycleStart - nextCycleStart;

            // Получаем количество игровых минут
            double durationInMinutes = duration.TotalMinutes;

            // Рассчитываем скорость с учетом тик-минут и минут на тик
            float speed = ((float)(durationInMinutes) / (_timeSettings.MinutesPerTick / _timeSettings.TickMinutes));

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