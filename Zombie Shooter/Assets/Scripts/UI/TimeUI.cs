using TMPro;
using UnityEngine;
using Zenject;

namespace ZombieShooter.TimeSystem
{
    public class TimeUI : MonoBehaviour
{
    [Inject] private ITimeHandler _timeHandler;
    private TextMeshProUGUI _timeText;

    private void Start()
    {
        _timeText = GetComponent<TextMeshProUGUI>();
        UpdateText();

        _timeHandler.OnTick += UpdateText;
    }

    private void OnDestroy()
    {
        _timeHandler.OnTick -= UpdateText;
    }

    private void UpdateText()
    {
        _timeText.text = _timeHandler.Time;
    }
}
}

