using System;

namespace ZombieShooter.TimeSystem
{
    public interface ITimeHandler
    {
        event Action OnTick;
        event Action<TimeCycle> OnNewCycle;
        event Action OnRestartCycle;
        string Time { get; }
        TimeCycle CurrentCycle { get; }
        TimeCycle NextCycle { get; }

    }
}