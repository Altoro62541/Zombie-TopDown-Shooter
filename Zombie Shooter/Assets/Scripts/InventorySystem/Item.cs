using System;
using System.Text;
using ZombieShooter.InventorySystem.SO;

namespace ZombieShooter.InventorySystem
{
    public struct Item : IIdentity
    {
        private ScriptableItem _reference;
        private string _guid;

        public string GUID => _guid;
        public string ReferenceGUID => _reference.GUID;

        public Item (ScriptableItem scriptableItem)
        {
            _reference = scriptableItem;
            _guid = Guid.NewGuid().ToString();
        }

        public override bool Equals(object obj)
        {
            if (obj is Item item)
            {
                return item.ReferenceGUID == ReferenceGUID || item.GUID == GUID;
            }
            return base.Equals(obj);
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new();
            stringBuilder.AppendLine($"GUID: {_guid}");
            stringBuilder.AppendLine($"Reference GUID: {ReferenceGUID}");
            stringBuilder.AppendLine($"Item Type: {_reference.GetType().Name}");
            stringBuilder.AppendLine($"Item Name: {_reference.Name}");
            return stringBuilder.ToString();
        }
    }
}
