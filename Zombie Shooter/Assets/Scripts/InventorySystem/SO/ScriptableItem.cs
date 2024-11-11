using Sirenix.OdinInspector;
using UnityEngine;
using ZombieShooter.SO;

namespace ZombieShooter.InventorySystem.SO
{
    public abstract class ScriptableItem : ScriptableObjectIdentity
    {
        [SerializeField, PreviewField(60)] private Sprite _icon;
        [SerializeField] private string _name;
        [SerializeField, TextArea] private string _description;

        public Sprite Icon => _icon;
        public string Name => _name;
        public string Description => _description;

        public virtual void Use ()
        {
            Debug.Log($"this item {_name} not have implementation using");
        }

        public abstract bool TryStack();
    }

}