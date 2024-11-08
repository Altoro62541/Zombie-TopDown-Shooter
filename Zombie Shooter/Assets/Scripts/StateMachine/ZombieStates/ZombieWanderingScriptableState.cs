using System;
using UnityEngine;
using ZombieShooter.States;
using ZombieShooter.ZombieEntity;

namespace ZombieShooter.StateMachine.ZombieStates
{
    [CreateAssetMenu(menuName = "State Machine/Zombies/States/Wandering")]
    public class ZombieWanderingScriptableState : ScriptableOwneringState<Zombie>
    {
        [SerializeField]  private float _radius;
        public override IState GetEntity(Zombie owner)
        {
            return new ZombieWanderingState(owner, _radius);
        }
    }
}
