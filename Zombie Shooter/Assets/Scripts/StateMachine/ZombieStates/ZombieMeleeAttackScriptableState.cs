using UnityEngine;
using ZombieShooter.States;
using ZombieShooter.ZombieEntity;

namespace ZombieShooter.StateMachine.ZombieStates
{
    [CreateAssetMenu(menuName = "State Machine/Zombies/States/Melee Attack State")]
    public class ZombieMeleeAttackScriptableState : ScriptableOwneringState<Zombie>
    {
        public override IState GetEntity(Zombie owner)
        {
            return new ZombieMeleeAttackState(owner);
        }
    }
}
