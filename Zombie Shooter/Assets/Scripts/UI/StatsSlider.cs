using UnityEngine;
using UnityEngine.UI;
using UniRx;

public abstract class StatsSlider : MonoBehaviour
{
    protected abstract ReactiveProperty<float> Stat { get; }
    private Slider _slider;

    private void Start()
    {
        _slider = GetComponent<Slider>();
        Stat.Subscribe(value => UpdateSlider(value)).AddTo(this); 
        UpdateSlider(Stat.Value); 
    }

    private void UpdateSlider(float value)
    {
        if (_slider != null)
            _slider.value = value; 
    }
}
