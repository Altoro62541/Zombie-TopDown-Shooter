namespace ZombieShooter
{
    public interface IDespawn
    {
        public float Time { get; set; }
        public bool IsActive { get; set; }
        public bool IsActiveAwake { get;}
    }
}