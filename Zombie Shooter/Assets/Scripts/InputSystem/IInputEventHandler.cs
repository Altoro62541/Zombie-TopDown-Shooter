using System;
using UnityEngine;

namespace ZombieShooter.InputSystem
{
    public interface IInputEventHandler
    {
        event Action<Vector2> OnLeftButton;
    }
}
