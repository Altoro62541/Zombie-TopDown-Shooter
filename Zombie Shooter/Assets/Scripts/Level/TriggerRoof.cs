using DG.Tweening;
using UnityEngine;
using ZombieShooter.PlayerEntity;
namespace ZombieShooter.Level
{
    public class TriggerRoof : MonoBehaviour
    {
        [SerializeField] private TriggerRoofConfig _config; 
        private SpriteRenderer _spriteRenderer;
        private Color _alphaColor;
        private Color _defaultColor;
        private Tween _currentTween;

        private void Start()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _alphaColor = _spriteRenderer.color;
            _alphaColor.a = 0;
            _defaultColor = _spriteRenderer.color;
        }

        private void OnTriggerEnter2D(Collider2D collider2D)
        {
            if(collider2D.TryGetComponent(out IPlayer player))
            {
                
                _currentTween?.Kill();
                _currentTween = _spriteRenderer.DOColor(_alphaColor, _config.Speed);
            }
            
        }
        private void OnTriggerExit2D(Collider2D collider2D)
        {
            if(collider2D.TryGetComponent(out IPlayer player))
            {
                _currentTween?.Kill();
                _currentTween = _spriteRenderer.DOColor(_defaultColor, _config.Speed);
            }
        }
    }
}
