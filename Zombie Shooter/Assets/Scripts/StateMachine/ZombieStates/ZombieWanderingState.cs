using UnityEngine;
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

            Target.AI.MoveTo(randomPoint);
        }

        public override void Exit()
        {
        }

        public void OnFixedUpdate()
        {
            if (Target.AI.IsEndingMove)
            {
                Target.StateMachine.TurnIdle();
            }
        }
    }
}
