using UniRx;
using ZombieShooter.InventorySystem.SO;

namespace ZombieShooter.InventorySystem.WeaponSystem.Handlers
{
    public interface IWeaponHandler
    {
        IReactiveCommand<IWeapon> OnEquip {  get; }
        IWeapon ActiveWeapon { get; }
        void Equip(Weapon weapon);
        void Equip(WeaponItem weapon);
        void Equip(Item item);
    }
}