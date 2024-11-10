using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;
namespace ZombieShooter.States
{
    public abstract class StateContainer<T> : ScriptableObject
    {
        [SerializeField] private StateContainer<T> _parent;
        [SerializeField] private ScriptableOwneringState<T>[] _states = new ScriptableOwneringState<T>[0];

        public IEnumerable<EntityState<T>> GetStates (T owner)
        {
            if (owner is null)
            {
                throw new ArgumentNullException(nameof(owner));
            }

            List<EntityState<T>> states = new();

            foreach (var state in _states)
            {
                EntityState<T> newEntity = state.GetEntity(owner) as EntityState<T>;
                states.Add(newEntity);
            }

            if (_parent != null)
            {
                var parentStates = _parent.GetStates(owner);

                states = parentStates.Concat(states).ToList();
            }

            return states;
        }
    }
}