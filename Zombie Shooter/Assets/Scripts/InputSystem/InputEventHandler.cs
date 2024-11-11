using System;
using UnityEngine;
namespace ZombieShooter.InputSystem
{
    public class InputEventHandler : MonoBehaviour, IInputEventHandler
    {
        public event Action OnLeftButton;
        public event Action OnRightButton;

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                OnLeftButton?.Invoke();
            }

            if (Input.GetMouseButtonDown(1))
            {
                OnRightButton?.Invoke();
            }
        }


    }

}