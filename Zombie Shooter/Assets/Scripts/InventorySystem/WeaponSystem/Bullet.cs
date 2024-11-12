using UnityEngine;
using ZombieShooter.ZombieEntity;

namespace ZombieShooter.InventorySystem.WeaponSystem
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Bullet : MonoBehaviour, IBullet
    {
        
        private Rigidbody2D _body;
        private BulletParams _params;
        private Vector3 _startPosition;

        public Transform Transform => transform;

        private void Awake()
        {
            _body = GetComponent<Rigidbody2D>();
        }

        public void SetData(BulletParams data)
        {
            _params = data;
        }

        private void Update()
        {
            float angle = transform.eulerAngles.z * Mathf.Deg2Rad;

            float horizontalSpeed = Mathf.Cos(angle) * 10f;
            float verticalSpeed = Mathf.Sin(angle) * 10f;

            _body.velocity = new Vector2(horizontalSpeed, verticalSpeed);

            if (Vector2.Distance(transform.position, _startPosition) >= _params.DistanceLive)
            {
                gameObject.SetActive(false);
            }

           
        }

        private void OnEnable()
        {
            _startPosition = transform.position;
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.collider.TryGetComponent(out IZombie zombie))
            {
                zombie.HeathComponent.Damage(_params.Damage, _params.Owner);
                gameObject.SetActive(false);
            }
        }
    }
}