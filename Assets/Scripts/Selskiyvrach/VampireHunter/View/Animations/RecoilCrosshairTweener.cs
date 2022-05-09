using DG.Tweening;
using Selskiyvrach.VampireHunter.View.Combat;
using UnityEngine;

namespace Selskiyvrach.VampireHunter.View.Animations
{
    public class RecoilCrosshairTweener : Tweener
    {
        [SerializeField] private CanvasGroup _alphaGroup;
        [SerializeField] private RectTransform _toScale;
        [SerializeField] private float _recoilRadiusFactor;
        [SerializeField] private float _duration;
        [SerializeField] private Ease _ease;
        [SerializeField] private CrosshairRadiusProviderBase _normalRadiusProvider;
        [SerializeField] private float _backDuration;
        [SerializeField] private Ease _backEase;
        [SerializeField] private Ease _alphaEase;
        
        private Tween _scaleTween;
        private Tween _alphaTween;
        
        public override void Play()
        {
            var startScale = _toScale.localScale;
            _toScale.localScale = Vector3.one;
            var normalSize = _toScale.sizeDelta;
            var requiredSize = new Vector2(_normalRadiusProvider.Radius, _normalRadiusProvider.Radius);
            var requiredScale = requiredSize / normalSize;
            _toScale.localScale = startScale;
            
            Kill();
            _scaleTween = _toScale.DOScale(requiredScale * _recoilRadiusFactor, _duration).SetEase(_ease).OnComplete(() =>
                _toScale.DOScale(requiredScale, _backDuration).SetEase(_backEase).OnComplete(Complete));
            _alphaTween = _alphaGroup.DOFade(0, _duration).SetEase(_alphaEase);
        }

        public override void Kill()
        {
            _scaleTween?.Kill();
            _alphaTween?.Kill();
        }
    }
}