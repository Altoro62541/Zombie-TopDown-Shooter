using UnityEngine;
namespace ZombieShooter.ZombieEntity
{
    public class Despawn : MonoBehaviour
    {
     void Start()
     {
        Destroy(gameObject, 60f);
     }
    }
}

