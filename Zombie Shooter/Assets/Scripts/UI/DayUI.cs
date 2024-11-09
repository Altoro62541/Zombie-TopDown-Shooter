using TMPro;
using UnityEngine;
using Zenject;

namespace ZombieShooter.TimeSystem
{
    public class DayUI : MonoBehaviour
{
    [Inject] private IDayCounterHandler _dayHandler;
    private TextMeshProUGUI _timeText;

    private void Start()
    {
        _timeText = GetComponent<TextMeshProUGUI>();
        UpdateText();
    }

        private void OnEnable()
        {
            _dayHandler.OnNewDay += UpdateText;
        }

        private void OnDestroy()
    {
        _dayHandler.OnNewDay -= UpdateText; 
    }

    private void UpdateText()
    {
        _timeText.text = $"Day: {_dayHandler.CurrentDay}"; 
    }
}
}


