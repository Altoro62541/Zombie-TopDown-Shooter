using Cysharp.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using ZombieShooter.States;
using ZombieShooter.ZombieEntity;
using Random = UnityEngine.Random;

namespace ZombieShooter.StateMachine.ZombieStates
{
    public class ZombieIdleState : EntityState<Zombie>
    {
        private AnimationCurve _wanderingCurve;
        public ZombieIdleState(Zombie target, AnimationCurve startWanderingCurve) : base(target)
        {
            _wanderingCurve = startWanderingCurve;
        }

        public override void Enter()
        {
            TurnWanderingDelay();
        }

        public override void Exit()
        {
        }

        private async void TurnWanderingDelay()
        {
            float min = _wanderingCurve[0].value;
            float max = _wanderingCurve[1].value;

            float time = Random.Range(min, max);

            TimeSpan timeSpan = TimeSpan.FromSeconds(time);

            await UniTask.Delay(timeSpan);

            Target.StateMachine.TurnWandering();
        }



    }
}
