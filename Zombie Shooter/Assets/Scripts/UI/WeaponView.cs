using UnityEngine;
using Zenject;
using ZombieShooter.InventorySystem.WeaponSystem.Handlers;
using UnityEngine.UI;
using TMPro;
using Cysharp.Threading.Tasks;
using UniRx;

namespace ZombieShooter.UI
{
    public class WeaponView : MonoBehaviour
    {
        [Inject] private IWeaponHandler _weaponHandler;
        [SerializeField] private Image _weaponImage;
        [SerializeField] private TextMeshProUGUI _weaponText;
        [SerializeField] private TextMeshProUGUI _ammoText;
         private CompositeDisposable _disposable = new();


        private void Awake()
        {
            _weaponImage = GetComponent<Image>();
            _weaponText = GetComponent<TextMeshProUGUI>();
            _ammoText = GetComponent<TextMeshProUGUI>();
            UpdateView();
        }
        private void OnEnable()
        {
            // _weaponHandler.OnEquip.Subscribe(weapon => {
            //     UpdateView();
            //    weapon.OnShoot += UpdateView;
            // }).AddTo(_disposable);

        }
        private void OnDestroy()
        {
            _disposable.Clear();
            _weaponHandler.ActiveWeapon.OnShoot -= UpdateView;
        }
        private void UpdateView()
        {
            Debug.Log(_weaponHandler.ActiveWeapon);
            _weaponImage.sprite = _weaponHandler.ActiveWeapon.Icon;
            _weaponImage.SetNativeSize();
            _weaponText.text = $"Weapon: {_weaponHandler.ActiveWeapon.Name}";
            _ammoText.text = $"Bullets: {_weaponHandler.ActiveWeapon.CurrentAmmunition}/{_weaponHandler.ActiveWeapon.AmmunitionBank}";
        }
    }
}

