using DG.Tweening;
using UnityEngine;

namespace ZombieShooter.Extensions
{
    public static class MonoBehaviourExtensions
    {
        public static void DODestroy(this MonoBehaviour monoBehaviour, float speedDestroy)
        {
            if (monoBehaviour.gameObject.TryGetComponent(out SpriteRenderer spriteRenderer))
            {
                var colorAlpha = spriteRenderer.color;
                colorAlpha.a = 0;
                spriteRenderer.DOColor(colorAlpha, speedDestroy).OnComplete(() => MonoBehaviour.Destroy(monoBehaviour.gameObject));

            }

            else
            {
                Debug.LogError($"GameObject {monoBehaviour.gameObject.name} not havecomponent {typeof(SpriteRenderer)}");
            }
        }
    }
}
