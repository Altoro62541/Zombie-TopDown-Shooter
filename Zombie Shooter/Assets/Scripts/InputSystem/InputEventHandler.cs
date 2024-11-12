using System;
using UnityEngine;
namespace ZombieShooter.InputSystem
{
    public class InputEventHandler : MonoBehaviour, IInputEventHandler
    {
        public event Action OnLeftButton;
        public event Action OnRightButton;
        public event Action OnReloadButton;
        public event Action OnPickEButton;

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

            if (Input.GetKeyDown(KeyCode.R))
            {
                OnReloadButton?.Invoke();
            }
            
            if (Input.GetKeyDown(KeyCode.E))
            {
                OnPickEButton?.Invoke();
            }
        }


    }

}