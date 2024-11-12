using System;
using UnityEngine;
using ZombieShooter.PlayerEntity;
using ZombieShooter.States;
using ZombieShooter.ZombieEntity;

namespace ZombieShooter.StateMachine.ZombieStates
{
    public class ZombieMoveToPlayerState : EntityState<Zombie>, IFixedUpdatableState, IGeterData<IPlayer>
    {
        private IPlayer _player;

        public ZombieMoveToPlayerState(Zombie target) : base(target)
        {
        }

        public override void Enter()
        {
            if(Target.Despawn.IsActiveAwake)
                Target.Despawn.IsActive = false;
            _player.HeathComponent.OnDead += OnDeadPlayer;
        }

        private void OnDeadPlayer()
        {
            _player.HeathComponent.OnDead -= OnDeadPlayer;
            Target.StateMachine.TurnIdle();
        }

        public override void Exit()
        {
            if(Target.Despawn.IsActiveAwake)
                Target.Despawn.IsActive = true;
            _player.HeathComponent.OnDead -= OnDeadPlayer;
        }

        public void OnFixedUpdate()
        {
            Target.AI.MoveTo(_player.Position);
            float distance = Vector2.Distance(_player.Position, Target.Position);
            if (distance <= 0.4f)
            {
                Target.AI.Stop();
                Target.StateMachine.TurnMeleeAttackPlayer(_player);
            }

            else if (distance >= Target.Data.DitanceAggresive)
            {
                Target.StateMachine.TurnIdle();
            }

            
        }

        public void SetData(IPlayer player)
        {
            _player = player;
        }
    }
}
