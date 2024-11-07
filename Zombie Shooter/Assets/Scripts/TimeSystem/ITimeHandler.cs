using System;

namespace ZombieShooter.TimeSystem
{
    public interface ITimeHandler
    {
        event Action OnTick;
        event Action<TimeCycle> OnNewCycle;
        string Time { get; }
        TimeCycle CurrentCycle { get; }
        TimeCycle NextCycle { get; }

    }
}