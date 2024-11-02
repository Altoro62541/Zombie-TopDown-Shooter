using Zenject;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    [Inject] private Player _player;
    void Start()
    {
        //Debug.Log(_player);
    }
    
}
