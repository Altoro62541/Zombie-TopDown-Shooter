using System;
using UnityEngine;

namespace ZombieShooter.InputSystem
{
    public interface IInputEventHandler
    {
        event Action OnLeftButton;
        event Action OnRightButton;
    }
}
