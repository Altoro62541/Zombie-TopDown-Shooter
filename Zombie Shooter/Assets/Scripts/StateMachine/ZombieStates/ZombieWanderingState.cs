using System.Threading;
using UnityEngine;
using ZombieShooter.Helpers;
using ZombieShooter.PlayerEntity;
using ZombieShooter.States;
using ZombieShooter.ZombieEntity;
using Random = UnityEngine.Random;

namespace ZombieShooter.StateMachine.ZombieStates
{
    public class ZombieWanderingState : EntityState<Zombie>, IFixedUpdatableState
    {
        private float _radius;

        public ZombieWanderingState(Zombie target, float radius) : base(target)
        {
            _radius = radius;
        }

        public override void Enter()
        {
            Vector3 randomPoint = Random.insideUnitCircle * _radius;
            randomPoint = randomPoint + Target.transform.position;
            Target.HeathComponent.OnHit += OnHit;

            Target.AI.MoveTo(randomPoint);
        }

        public override void Exit()
        {
            Target.HeathComponent.OnHit -= OnHit;
        }

        private void OnHit(object damager)
        {
            if (damager is IPlayer player)
            {
                Target.StateMachine.TurnMoveToPlayer(player);
            }
        }

        public void OnFixedUpdate()
        {
            if (Target.AI.IsEndingMove)
            {
                Target.StateMachine.TurnIdle();
            }
            if (ZombieVisionHelper.TryGetPlayerInSphere(Target.Position, Vector3.one, Target.Data.VisionRadius, out IPlayer player))
            {
                Target.StateMachine.TurnMoveToPlayer(player);
            }


        }
    }
}
