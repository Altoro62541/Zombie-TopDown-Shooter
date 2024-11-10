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

namespace ZombieShooter.StateMachine.ZombieStates
{
    public class ZombieMeleeAttackState : EntityState<Zombie>, IGeterData<IPlayer>, IFixedUpdatableState
    {
        CancellationTokenSource _cancellationTokenSource = new();
        private IPlayer _player;

        public ZombieMeleeAttackState(Zombie target) : base(target)
        {
        }

        public override void Enter()
        {
            Target.AI.Stop();
            _cancellationTokenSource = new();
            Attack().Forget();
        }

        public override void Exit()
        {
            _cancellationTokenSource?.Cancel();
        }

        public void SetData(IPlayer player)
        {
            _player = player;
        }

        public void OnFixedUpdate()
        {
            float distance = Vector2.Distance(_player.Position, Target.Position);
            if (distance >= 0.6f)
            {
                Target.StateMachine.TurnMoveToPlayer(_player);
            }
        }

        private async UniTask Attack ()
        {
            while (true)
            {
                TimeSpan timeSpan = TimeSpan.FromSeconds(Target.Data.SpeedAttack);
                await UniTask.Delay(timeSpan, cancellationToken: _cancellationTokenSource.Token);
                _player.HeathComponent.Damage(Target.Data.Damage, Target);
            }
        }
    }
}
