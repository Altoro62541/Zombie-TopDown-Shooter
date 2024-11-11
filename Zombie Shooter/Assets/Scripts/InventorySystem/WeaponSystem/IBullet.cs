using ZombieShooter.Factories;

namespace ZombieShooter.InventorySystem.WeaponSystem
{
    public interface IBullet : ITransformable, IGeterData<BulletParams>, IFactoryObject
    {
    }
}