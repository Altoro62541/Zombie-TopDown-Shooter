namespace ZombieShooter.States
{
    public abstract class EntityState<T> : IState
    {
        protected T Target { get; private set; }
        protected EntityState(T target)
        {
            Target = target;
        }

        public abstract void Enter();

        public abstract void Exit();




    }
}
