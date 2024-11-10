using System.Collections;
using UnityEngine;

namespace ZombieShooter.ZombieEntity
{
    public class ZombiePhysics : MonoBehaviour, IZombiePhysics
    {
        private CircleCollider2D _collider;

        public float Radius => _collider.radius;

        private void Awake()
        {
            _collider = GetComponent<CircleCollider2D>();
        }
    }
}