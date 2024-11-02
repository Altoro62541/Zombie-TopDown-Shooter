using System;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public event Action OnTouch;
    private void Update()
    {
         if (Input.GetMouseButtonDown(0))
         {
             OnTouch?.Invoke();
             Debug.Log(OnTouch);
         }
    }
}
