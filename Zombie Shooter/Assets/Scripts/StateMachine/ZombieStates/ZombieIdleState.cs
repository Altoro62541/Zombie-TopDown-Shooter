using Cysharp.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
using ZombieShooter.Helpers;
using ZombieShooter.PlayerEntity;
using ZombieShooter.States;
using ZombieShooter.ZombieEntity;
using Random = UnityEngine.Random;

namespace ZombieShooter.StateMachine.ZombieStates
{
    public class ZombieIdleState : EntityState<Zombie>, IFixedUpdatableState
    {
        CancellationTokenSource _cancellationTokenSource = new();
        private AnimationCurve _wanderingCurve;
        public ZombieIdleState(Zombie target, AnimationCurve startWanderingCurve) : base(target)
        {
            _wanderingCurve = startWanderingCurve;
        }

        public override void Enter()
        {
            if(Target.Despawn.IsActiveAwake)
            {   
                Target.Despawn.IsActive = true;
                
            }
            Target.AI.Stop();
            _cancellationTokenSource = new();
            TurnWanderingDelay();
            Target.HeathComponent.OnHit += OnHit;
            
        }

        private void OnHit(object damager)
        {
            if (damager is IPlayer player)
            {
                Target.StateMachine.TurnMoveToPlayer(player);
            }
        }

        public override void Exit()
        {
            if (_cancellationTokenSource != null && !_cancellationTokenSource.IsCancellationRequested)
            {
                _cancellationTokenSource.Cancel();
            }
            Target.HeathComponent.OnHit -= OnHit;
        }

        public void OnFixedUpdate()
        {
            if (ZombieVisionHelper.TryGetPlayerInSphere(Target.Position, Target.transform.forward, Target.Data.VisionRadius, out IPlayer player))
            {
                Target.StateMachine.TurnMoveToPlayer(player);
            }
        }

        private async void TurnWanderingDelay()
        {
            float min = _wanderingCurve[0].value;
            float max = _wanderingCurve[1].value;

            float time = Random.Range(min, max);

            TimeSpan timeSpan = TimeSpan.FromSeconds(time);

            await UniTask.Delay(timeSpan, cancellationToken: _cancellationTokenSource.Token);

            Target.StateMachine.TurnWandering();
        }



    }
}
