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

        private void OnEnable()
        {
            _weaponHandler.OnEquip.Subscribe(weapon => {
                 UpdateView();
               weapon.OnShoot += UpdateView;
                weapon.OnReloadFinish += UpdateView;
            }).AddTo(_disposable);

        }
        private void OnDestroy()
        {
            _disposable.Clear();
            try
            {
                _weaponHandler.ActiveWeapon.OnShoot -= UpdateView;
                _weaponHandler.ActiveWeapon.OnReloadFinish -= UpdateView;
            }
            catch
            {
            }
            
        }
        private void UpdateView()
        {
            _weaponImage.sprite = _weaponHandler.ActiveWeapon.Icon;
            _weaponImage.SetNativeSize();
            _weaponText.text = _weaponHandler.ActiveWeapon.Name;
            _ammoText.text = $"{_weaponHandler.ActiveWeapon.CurrentAmmunition}/{_weaponHandler.ActiveWeapon.AmmunitionBank}";
        }
    }
}

