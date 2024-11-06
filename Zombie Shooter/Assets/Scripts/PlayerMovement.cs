using System;
using UnityEngine;

    public class PlayerMovement : MonoBehaviour
    {
        protected Rigidbody2D _body;
        [SerializeField, Min(0.1f)] private float _moveSpeed = 5;
        private bool _isMoving = false;
        private Vector2 _targetPosition;


        private void Start ()
        {
            _body = GetComponent<Rigidbody2D>();
        }
        private void Update()
        {
        if (Input.GetMouseButtonDown(0))
        {
            _targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            _isMoving = true;
        }

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
    }

