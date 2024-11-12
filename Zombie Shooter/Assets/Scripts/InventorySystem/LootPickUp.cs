using UnityEngine;
using UnityEngine.AddressableAssets;
using Zenject;
using ZombieShooter.InputSystem;
using ZombieShooter.InventorySystem.Handlers;
using ZombieShooter.InventorySystem.SO;
using ZombieShooter.PlayerEntity;
namespace ZombieShooter.InventorySystem
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class LootPickUp : MonoBehaviour
    {
    [Inject] private IInventoryHandler _inventory;
    [Inject] private IInputEventHandler _inputEventHandler;
    [Inject] private IScriptableItemLoader _scriptableItemLoader;
    [SerializeField] private AssetReferenceT<ScriptableItem> _scriptableItem;  

    private bool _isPickable;

    private async void Start()
    {
        if (_scriptableItem != null)
        {

            var _item = await _scriptableItemLoader.LoadScriptableItemAsync<ScriptableItem>(_scriptableItem);
            
            var spriteRenderer = GetComponent<SpriteRenderer>();
            spriteRenderer.sprite = _item.Icon;

        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out IPlayer _))
        {
            _isPickable = true;
        }
    }
     private void OnTriggerExit2D(Collider2D other)
    {
        if (other.TryGetComponent(out IPlayer _))
        {
            _isPickable = true;
        }
    }
    private void OnEnable()
    {
        _inputEventHandler.OnPickEButton += PickUpItem;
    }
    private void OnDisable()
    {
        _inputEventHandler.OnPickEButton -= PickUpItem;
    }

    private void PickUpItem()
    {
        if(_isPickable)
        {
            Debug.Log(_scriptableItem);
            _inventory.Add(_scriptableItem);
            gameObject.SetActive(false);
        }
       
    }
    }
}

