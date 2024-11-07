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
            // Передаем цвет следующего цикла и скорость в метод TurnCycle
            _lightProvider.TurnCycle(_timeHandler.CurrentCycle.Color, _timeHandler.CurrentCycle.Intensity, 0);
            TurnNextCycle(_timeHandler.NextCycle);

        }

        private void TurnNextCycle (TimeCycle timeCycle)
        {
            // Получаем время начала текущего и следующего цикла
            var currentCycleStart = _timeHandler.CurrentCycle.StartTime;
            var nextCycleStart = _timeHandler.NextCycle.StartTime;

            // Вычисляем разницу во времени между текущим и следующим циклом
            TimeSpan duration = currentCycleStart - nextCycleStart;

            // Преобразуем разницу в минуты
            double durationInMinutes = duration.TotalMinutes;

            // Если 1 игровая минута = 1 реальная секунда, то скорость будет равна разнице в минутах
            float speed = (float)durationInMinutes; // Это будет количество секунд для перехода

            if (speed < 0)
            {
                speed *= -1;
            }

            Debug.Log(speed);

            // Передаем цвет следующего цикла и скорость в метод TurnCycle
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