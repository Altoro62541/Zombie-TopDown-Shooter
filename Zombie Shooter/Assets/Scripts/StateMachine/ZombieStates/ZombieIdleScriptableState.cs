using UnityEngine;
using ZombieShooter.States;
using ZombieShooter.ZombieEntity;

namespace ZombieShooter.StateMachine.ZombieStates
{
    [CreateAssetMenu(menuName = "State Machine/Zombies/States/Idle")]
    public class ZombieIdleScriptableState : ScriptableOwneringState<Zombie>
    {
        [SerializeField] private AnimationCurve _wanderingCurve;
        public override IState GetEntity(Zombie owner)
        {
            return new ZombieIdleState(owner, _wanderingCurve);
        }
    }
}
