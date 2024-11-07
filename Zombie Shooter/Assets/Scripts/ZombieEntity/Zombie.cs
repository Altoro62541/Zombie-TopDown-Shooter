using Zenject;
using UnityEngine;
using Zenject.SpaceFighter;
namespace ZombieShooter.ZombieEntity
{
    public class Zombie : MonoBehaviour
    {
        [Inject] private Player _player;
        private void Start()
        {
            //Debug.Log(_player);
        }

    }

}
