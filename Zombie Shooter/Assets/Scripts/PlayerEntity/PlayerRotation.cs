using Sirenix.OdinInspector;
using UnityEngine;
namespace ZombieShooter.PlayerEntity
{
    public class PlayerRotation : MonoBehaviour
    {
        [SerializeField, MinValue(0.1f)] private float _rotationSpeed = 5;
        private IPlayerMovement _movement;

        private void Awake()
        {
            _movement = GetComponent<IPlayerMovement>();
        }

        private void Update()
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 direction = (mousePos - transform.position).normalized;

            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            Quaternion targetRotation = Quaternion.Euler(0f, 0f, angle);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, _rotationSpeed * Time.deltaTime);
        }
    }

}