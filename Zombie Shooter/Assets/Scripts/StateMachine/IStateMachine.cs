using System;
using UnityEngine.Events;

namespace ZombieShooter.States
{
    public interface IStateMachine<TTarget>
    {
        event UnityAction<IState> OnStateChanged;

        IState Current { get; }

        TTarget Owner { get; }

        IState DefaulTTarget { get; }
    }
}