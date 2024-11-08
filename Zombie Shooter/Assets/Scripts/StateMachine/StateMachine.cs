using Cysharp.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

namespace ZombieShooter.States
{
    public abstract class StateMachine<TTarget> : MonoBehaviour, IStateMachine<TTarget>
    {
        private bool _enabled = true;
        public event UnityAction<IState> OnStateChanged;
        [SerializeField] private StateContainer<TTarget> _container;

        private TTarget _owner;
        private Dictionary<Type, IState> _statesDictionary;

        public IState Current { get; private set; }

        public TTarget Owner => _owner;

        public IState DefaulTTarget => _statesDictionary.First().Value;

        public bool Enabled
        {
            get
            {
                return _enabled;
            }

            set
            {
                _enabled = value;
                enabled = _enabled;
            }
        }

        protected virtual void Awake()
        {
            if (!TryGetComponent(out _owner))
            {
                throw new NullReferenceException($"Owner not found with type {typeof(TTarget)} on State Machine {GetType()}");
            }
            Initialize(_container.GetStates(_owner));
        }

        protected virtual void Start()
        {
            SetStateByDefault();
        }

        private void Initialize(IEnumerable<IState> states)
        {
            _statesDictionary = new();

            _statesDictionary = states.ToDictionary(state => state.GetType());
        }

        public void SetState<T>() where T : IState
        {
            Type stateType = typeof(T);

            SetState(stateType);
        }

        public T GetState<T>() where T : IState
        {
            Type stateType = typeof(T);

            return (T)_statesDictionary[stateType];
        }

        public void SetState(Type stateType)
        {
            if (!_enabled)
            {
                return;
            }

            if (!_statesDictionary.ContainsKey(stateType))
            {
                throw new KeyNotFoundException($"state with key {stateType.Name} not found");
            }
            Current?.Exit();

            Current = _statesDictionary[stateType];

            Current.Enter();;
            OnStateChanged?.Invoke(Current);

        }

        public virtual void SetStateByDefault ()
        {
            SetState(DefaulTTarget.GetType());
        }

        public void StopState()
        {
            Current?.Exit();
            Current = null;
        }



        public void Update()
        {
            if (Current is null)
            {
                return;
            }

            else if (Current is IUpdatableState updateState)
            {
                updateState.OnUpdate();
            }
        }

        public void FixedUpdate()
        {
            if (Current is null)
            {
                return;
            }

            else if (Current is IFixedUpdatableState fixedUpdateState)
            {
                fixedUpdateState.OnFixedUpdate();
            }
        }

        public void LateUpdate()
        {
            if (Current is null)
            {
                return;
            }

            else if (Current is ILateableState lateUpdateState)
            {
                lateUpdateState.OnLateUpdate();
            }
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (Current is null)
            {
                return;
            }
            if (Current is ICollisionState collisionState)
            {
                collisionState.CollisionEnter(collision);
            }

            else if (Current is ICollisionEnterState collisionEnterState)
            {
                collisionEnterState.CollisionEnter(collision);
            }
        }

        private void OnCollisionStay(Collision collision)
        {
            if (Current is null)
            {
                return;
            }
            if (Current is ICollisionState collisionState)
            {
                collisionState.CollisionStay(collision);
            }

            else if (Current is ICollisionStayState collisionStayState)
            {
                collisionStayState.CollisionStay(collision);
            }
        }

        private void OnCollisionExit(Collision collision)
        {
            if (Current is null)
            {
                return;
            }
            if (Current is ICollisionState collisionState)
            {
                collisionState.CollisionExit(collision).Forget();
            }

            else if (Current is ICollisionExitState collisionExitState)
            {
                collisionExitState.CollisionExit(collision).Forget();
            }
        }
    }
}
