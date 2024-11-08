using UnityEngine;
namespace ZombieShooter.States
{
    public abstract class ScriptableOwneringState<T> : ScriptableObject
    {
        public abstract IState GetEntity (T owner);
    }
}