﻿using System;
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
        }

        public override void Exit()
        {
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