using System;
using UnityEngine;
using ZombieShooter.InputSystem;
namespace ZombieShooter.InputSystem
{
    public class InputEventHandler : MonoBehaviour, IInputEventHandler
    {
        public event Action<Vector2> OnLeftButton;
        // public event Action<Vector2> OnTouch;
        // private void Update()
        // {
        //      if (Input.GetMouseButtonDown(0))
        //      {
        //         OnTouch?.Invoke(Input.mousePosition);
        //         Debug.Log(OnTouch);
        //      }
        // }
    }

}