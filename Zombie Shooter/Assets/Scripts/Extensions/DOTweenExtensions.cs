using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace ZombieShooter.Extensions
{
    public static class DOTweenExtensions
    {
        public static TweenerCore<Color, Color, ColorOptions> DOColor(this Light2D target, Color endValue, float duration)
        {
            TweenerCore<Color, Color, ColorOptions> tweenerCore = DOTween.To(() => target.color, delegate (Color x)
            {
                target.color = x;
            }, endValue, duration);
            tweenerCore.SetTarget(target);
            return tweenerCore;
        }

        public static TweenerCore<float, float, FloatOptions> DOIntensity(this Light2D target, float endValue, float duration)
        {
            TweenerCore<float, float, FloatOptions> tweenerCore = DOTween.To(() => target.intensity, delegate (float x)
            {
                target.intensity = x;
            }, endValue, duration);
            tweenerCore.SetTarget(target);
            return tweenerCore;
        }
    }
}
