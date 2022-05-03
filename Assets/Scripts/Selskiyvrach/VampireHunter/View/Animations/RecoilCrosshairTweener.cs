using DG.Tweening;
using UnityEngine;

namespace Selskiyvrach.VampireHunter.View
{
    public class RecoilCrosshairTweener : Tweener
    {
        [SerializeField] private CanvasGroup _alphaGroup;
        [SerializeField] private Transform _toScale;
        [SerializeField] private Vector3 _targetRecoilValue;
        [SerializeField] private float _duration;
        [SerializeField] private Ease _ease;
        [SerializeField] private Vector3 _targetBackValue;
        [SerializeField] private float _backDuration;
        [SerializeField] private Ease _backEase;
        [SerializeField] private Ease _alphaEase;
        
        private Tween _scaleTween;
        private Tween _alphaTween;
        
        public override void Play()
        {
            Kill();
            _scaleTween = _toScale.DOScale(_targetRecoilValue, _duration).SetEase(_ease).OnComplete(() =>
                _toScale.DOScale(_targetBackValue, _backDuration).SetEase(_backEase).OnComplete(Complete));
            _alphaTween = _alphaGroup.DOFade(0, _duration).SetEase(_ease);
        }
        public override void Kill()
        {
            _scaleTween?.Kill();
            _alphaTween?.Kill();
        }
    }
}