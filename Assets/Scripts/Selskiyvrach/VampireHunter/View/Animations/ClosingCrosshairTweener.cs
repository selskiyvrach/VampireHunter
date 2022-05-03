using DG.Tweening;
using UnityEngine;

namespace Selskiyvrach.VampireHunter.View
{
    public class ClosingCrosshairTweener : Tweener
    {
        [SerializeField] private CanvasGroup _alphaGroup;
        [SerializeField] private Transform _toScale;
        [SerializeField] private Vector3 _targetValue;
        [SerializeField] private float _duration;
        [SerializeField] private Ease _ease;
        [Range(0, 1)]
        [SerializeField] private float _alphaStartTime = .5f;

        private Tween _scaleTween;
        private Tween _alphaTween;
        
        public override void Play()
        {
            _scaleTween = _toScale.DOScale(_targetValue, _duration).SetEase(_ease).OnComplete(Complete);
            _alphaTween = _alphaGroup.DOFade(1, _duration * _alphaStartTime);
        }

        public override void Kill()
        {
            _scaleTween?.Kill();
            _alphaTween?.Kill();
        }
    }
}