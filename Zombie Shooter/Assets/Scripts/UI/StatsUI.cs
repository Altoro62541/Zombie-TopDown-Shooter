using PlayerEntity.PlayerStatsSystem.Handlers;
using UnityEngine;
using Zenject;
using TMPro;
using UniRx;
using UnityEngine.UI;
namespace ZombieShooter.TimeSystem
{
    public class StatsUI : MonoBehaviour
    {
    [Inject] private IPlayerStatsHandler _playerStatsHandler;

    [SerializeField] private Slider _hungrySlider;
    [SerializeField] private Slider _sleepSlider;
    [SerializeField] private Slider _reasonSlider;
    [SerializeField] private Slider _thirstSlider;
    [SerializeField] private Slider _warmSlider;

    private TextMeshProUGUI _statsText;

    private CompositeDisposable _disposables = new CompositeDisposable();

    private void Start()
    {
        _statsText = GetComponent<TextMeshProUGUI>();
        SubscribeToStats();
        UpdateStatsUI(); 
    }

    private void SubscribeToStats()
    {
        var stats = _playerStatsHandler.Stats;

        stats.Hungry.Subscribe(_ => {
                _hungrySlider.value = stats.Hungry.Value;
            }).AddTo(_disposables);
        stats.Sleep.Subscribe(_ => UpdateStatsUI()).AddTo(_disposables);
        stats.Reason.Subscribe(_ => UpdateStatsUI()).AddTo(_disposables);
        stats.Thirst.Subscribe(_ => UpdateStatsUI()).AddTo(_disposables);
        stats.Warm.Subscribe(_ => UpdateStatsUI()).AddTo(_disposables);

        stats.Hungry.AddTo(_disposables);
        stats.Sleep.AddTo(_disposables);
        stats.Reason.AddTo(_disposables);
        stats.Thirst.AddTo(_disposables);
        stats.Warm.AddTo(_disposables);
    }


    private void UpdateStatsUI()
    {
        var stats = _playerStatsHandler.Stats;

        if (_hungrySlider != null) _hungrySlider.value = stats.Hungry.Value;
        if (_sleepSlider != null) _sleepSlider.value = stats.Sleep.Value;
        if (_reasonSlider != null) _reasonSlider.value = stats.Reason.Value;
        if (_thirstSlider != null) _thirstSlider.value = stats.Thirst.Value;
        if (_warmSlider != null) _warmSlider.value = stats.Warm.Value;

        if (_statsText != null)
        {
            _statsText.text = $"Hungry: {stats.Hungry.Value:0.0}\n" +
                              $"Sleep: {stats.Sleep.Value:0.0}\n" +
                              $"Reason: {stats.Reason.Value:0.0}\n" +
                              $"Thirst: {stats.Thirst.Value:0.0}\n" +
                              $"Warm: {stats.Warm.Value:0.0}";
        }
    }

    private void OnDestroy()
    {
        _disposables.Dispose();
    }
    }
}

