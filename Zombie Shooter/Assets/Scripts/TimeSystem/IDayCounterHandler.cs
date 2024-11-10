using System;
namespace ZombieShooter.TimeSystem
{
    internal interface IDayCounterHandler
    {
        long CurrentDay { get; }
        event Action OnNewDay;
    }
}