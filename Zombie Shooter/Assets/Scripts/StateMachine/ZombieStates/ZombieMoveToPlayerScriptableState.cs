using UnityEngine;
using ZombieShooter.States;
using ZombieShooter.ZombieEntity;

namespace ZombieShooter.StateMachine.ZombieStates
{
    [CreateAssetMenu(menuName = "State Machine/Zombies/States/Move To Player")]
    public class ZombieMoveToPlayerScriptableState : ScriptableOwneringState<Zombie>
    {
        public override IState GetEntity(Zombie owner)
        {
            return new ZombieMoveToPlayerState(owner);
        }
    }
}
