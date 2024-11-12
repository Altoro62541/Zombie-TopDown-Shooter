using System.Collections;
using UnityEngine;

namespace ZombieShooter.ZombieEntity
{
    public class ZombiePhysics : MonoBehaviour, IZombiePhysics
    {
        private CircleCollider2D _collider;

        public float Radius => _collider.radius;

        public bool Enabled { get => _collider.enabled; set => _collider.enabled = value; }

        private void Awake()
        {
            _collider = GetComponent<CircleCollider2D>();
        }
    }
}