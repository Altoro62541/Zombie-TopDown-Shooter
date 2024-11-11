using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;
using ZombieShooter.Extensions;
using ZombieShooter.InputSystem;
namespace ZombieShooter.PlayerEntity
{
    public class PlayerMovement : MonoBehaviour, IPlayerMovement
    {
        protected Rigidbody2D _body;
        [SerializeField, MinValue(0.1f)] private float _moveSpeed = 5;
        private bool _isMoving = false;
        private Vector2 _targetPosition;
        [Inject] private IInputEventHandler _inputEventHandler;
        [Inject] private EventSystem _eventSystem;

        public bool IsMoving => _isMoving;

        private void Start()
        {
            _body = GetComponent<Rigidbody2D>();
        }
        private void Update()
        {
            if (_isMoving)
            {
                Move(_targetPosition);
            }
        }


        public void Move(Vector3 point)
        {
            if (!_isMoving)
            {
                return;
            }

            Vector2 direction = (point - (Vector3)_body.position).normalized;
            Vector2 moveVelocity = direction * _moveSpeed;

            _body.MovePosition(_body.position + moveVelocity * Time.fixedDeltaTime);

            if (Vector2.Distance(point, _body.position) <= 0.1f)
            {
                _isMoving = false;
            }
        }

        private void OnLeftButton()
        {
            if (!_eventSystem.IsPointerOverUIObject())
            {
                _targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                _isMoving = true;
            }
        }

        private void OnEnable()
        {
            _inputEventHandler.OnLeftButton += OnLeftButton;
        }

        private void OnDisable()
        {
            _inputEventHandler.OnLeftButton -= OnLeftButton;
        }
    }

}

