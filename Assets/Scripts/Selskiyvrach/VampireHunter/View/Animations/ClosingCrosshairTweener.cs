using DG.Tweening;
using Selskiyvrach.VampireHunter.View.Combat;
using UnityEngine;

namespace Selskiyvrach.VampireHunter.View.Animations
{
    public class ClosingCrosshairTweener : Tweener
    {
        [SerializeField] private CanvasGroup _alphaGroup;
        [SerializeField] private RectTransform _toScale;
        [SerializeField] private float _scaleFactor = .5f;
        [SerializeField] private CrosshairRadiusProviderBase _radiusProvider;
        [SerializeField] private float _duration;
        [SerializeField] private Ease _ease;
        [Range(0, 1)]
        [SerializeField] private float _alphaStartTime = .5f;

        private Tween _scaleTween;
        private Tween _alphaTween;
        
        public override void Play()
        {
            var startScale = _toScale.localScale;
            _toScale.localScale = Vector3.one;
            var normalSize = _toScale.sizeDelta;
            var requiredSize = new Vector2(_radiusProvider.Radius, _radiusProvider.Radius) * _scaleFactor;
            var requiredScale = requiredSize / normalSize;
            _toScale.localScale = startScale;
            
            _scaleTween = _toScale.DOScale(requiredScale, _duration).SetEase(_ease).OnComplete(Complete);
            _alphaTween = _alphaGroup.DOFade(1, _duration * _alphaStartTime);
        }

        public override void Kill()
        {
            _scaleTween?.Kill();
            _alphaTween?.Kill();
        }
    }
}