namespace ZombieShooter.States
{
    public interface ILateableState : IState
    {
        void OnLateUpdate();
    }
}
