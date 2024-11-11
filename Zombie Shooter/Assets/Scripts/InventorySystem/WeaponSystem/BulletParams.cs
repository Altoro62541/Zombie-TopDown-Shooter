namespace ZombieShooter.InventorySystem.WeaponSystem
{
    public struct BulletParams
    {

        public float Damage { get; private set; }
        public float DistanceLive { get; private set; }

        public BulletParams(float damage, float distanceLive)
        {
            Damage = damage;
            DistanceLive = distanceLive;
        }
    }
}
