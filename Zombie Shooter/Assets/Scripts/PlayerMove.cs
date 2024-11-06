using System;
using UnityEngine;

    public class PlayerMove : MonoBehaviour
    {
        #region Fields
        protected Rigidbody2D _body;
        private float _moveSpeed = 5;
        private float _rotationSpeed = 5;
        private bool _isMoving = false;
        private Vector2 _targetPosition;

        #endregion


        private void Start ()
        {
            _body = GetComponent<Rigidbody2D>();
        }
        /// <summary>
        /// move character to point
        /// </summary>
        /// <param name="dir">target point</param>
        #region Interactions
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
        
        
        public void Move(Vector3 dir)
    {
        if (!_isMoving)
        {
            return;
        }

        Vector2 direction = (dir - (Vector3)_body.position).normalized;
        Vector2 moveVelocity = direction * _moveSpeed;

        _body.MovePosition(_body.position + moveVelocity * Time.fixedDeltaTime);

        if (Vector2.Distance(dir, _body.position) <= 0.1f)
        {
            _isMoving = false;
        }
    }
        

        /// <summary>
        /// rotate character to angle
        /// </summary>
        /// <param name="dir">direction target angle</param>
        public void Rotate(Vector3 dir) {
       
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

            Quaternion root = Quaternion.AngleAxis(angle, Vector3.forward);

            transform.rotation = Quaternion.Slerp(transform.rotation, root, _rotationSpeed * Time.deltaTime);
        }

        #endregion
    }

