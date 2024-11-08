namespace ZombieShooter.States
{
    public interface IUpdatableState : IState
    {
        void OnUpdate();
    }
}
