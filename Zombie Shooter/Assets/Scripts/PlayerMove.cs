using Unity.VisualScripting;
using UnityEngine;
using Zenject;
public class PlayerMove : MonoBehaviour
{
    [Inject] private PlayerInput _playerInput;
    private Rigidbody2D _rigidBody;
    private float _moveSpeed = 2f;
    private Vector3 _touchPosition, whereToMove;
    private bool _isMoving = false;
    private float _previousDistanceToTouchPos, _curretDistanceToTouchPos;
    

    private void Start()
    {
        _rigidBody = gameObject.GetComponent<Rigidbody2D>();
    }
    private void OnEnable()
    {
        _playerInput.OnTouch += Move;
    }
    private void FixedUpdate()
    {
        if (_isMoving)
            _curretDistanceToTouchPos = (_touchPosition - transform.position).magnitude;

        if (_curretDistanceToTouchPos > _previousDistanceToTouchPos)
        {
            _isMoving = false;
            _rigidBody.velocity = Vector2.zero;
        }

        if (_isMoving)
            _previousDistanceToTouchPos = (_touchPosition - transform.position).magnitude;
    }
    private void Move()
    {
        Debug.Log(nameof(Move));
        _previousDistanceToTouchPos = 0;
        _curretDistanceToTouchPos = 0;
        _isMoving = true;
        _touchPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        _touchPosition.z = 0;
        whereToMove = (_touchPosition - transform.position).normalized;
        _rigidBody.velocity = new Vector2(whereToMove.x * _moveSpeed, whereToMove.y * _moveSpeed); 
    }
}
