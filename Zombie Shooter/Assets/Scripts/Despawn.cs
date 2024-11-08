using Sirenix.OdinInspector;
using UnityEngine;
namespace ZombieShooter
{
    public class Despawn : MonoBehaviour
    {
        [SerializeField, MinValue(0.1f)] private float _time = 60;

        public float Time { get => _time; set => _time = value; }

        private void Start()
     {
        Destroy(gameObject, _time);
     }
    }
}

