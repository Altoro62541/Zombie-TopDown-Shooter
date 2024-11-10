using UnityEngine;
using UnityEngine.UI;
using UniRx;

public abstract class StatsSlider : MonoBehaviour
{
    private CompositeDisposable _disposables = new();
    protected abstract FloatReactiveProperty Stat { get; }
    private Slider _slider;

    private void Start()
    {
        _slider = GetComponent<Slider>();
        Stat.Subscribe(value => UpdateSlider(value)).AddTo(_disposables); 
        UpdateSlider(Stat.Value); 
    }

    private void UpdateSlider(float value)
    {
        if (_slider is null)
            _slider.value = value; 
    }

    private void OnDisable()
    {
        _disposables.Clear();
    }
}
