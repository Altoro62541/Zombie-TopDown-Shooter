using UnityEngine;
public class PlayerMove : MonoBehaviour
{
private Rigidbody2D _rigidBody;
private float _moveSpeed = 2.5f;
private Vector2 _direction;
private Vector3 _targetPosition;
private bool _isMoving = false;
private float _rotationSpeed = 360f; // Скорость поворота в градусах в секунду
private float _targetAngle;

private void Start()
{
    _rigidBody = gameObject.GetComponent<Rigidbody2D>();
}

private void Update()
{
    if (_isMoving)
    {
        _direction = (_targetPosition - transform.position).normalized;
        _rigidBody.velocity = _direction * _moveSpeed;

        _targetAngle = Mathf.Atan2(_direction.y, _direction.x) * Mathf.Rad2Deg;
        Quaternion targetRotation = Quaternion.Euler(0, 0, _targetAngle);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, _rotationSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, _targetPosition) <= 0.1f)
        {
            StopMovement();
        }
    }

    if (Input.GetMouseButtonDown(0))
    {
        StartMoving();
    }
}

private void StartMoving()
{
    _targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    _targetPosition.z = 0;
    _isMoving = true;
}

private void StopMovement()
{
    _isMoving = false;
    _rigidBody.velocity = Vector2.zero;
}
}
