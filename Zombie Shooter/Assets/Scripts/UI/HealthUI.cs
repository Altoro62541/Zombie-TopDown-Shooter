using Cysharp.Threading.Tasks;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using Zenject;
using ZombieShooter.PlayerEntity;
namespace ZombieShooter.UI
{
    public class HealthUI : MonoBehaviour
    {
        [Inject] IPlayer player;
        private Slider _slider;
        private CompositeDisposable _disposable = new();

        private void Start()
        {
            _slider = GetComponent<Slider>();
            player.HeathComponent.Health.Subscribe(_ => {
                _slider.value = player.HeathComponent.Health.Value;
            }).AddTo(_disposable);
        }
        private void OnDisable()
        {
           _disposable.Clear();
        }

    }
}

