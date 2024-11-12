namespace ZombieShooter.InventorySystem.WeaponSystem
{
    public struct BulletParams
    {

        public float Damage { get; private set; }
        public float DistanceLive { get; private set; }
        public object Owner { get; private set; }

        public BulletParams(float damage, float distanceLive, object owner = null)
        {
            Damage = damage;
            DistanceLive = distanceLive;
            Owner = owner;
        }
    }
}
