using DG.Tweening;
using UnityEngine;

namespace Selskiyvrach.VampireHunter.View
{
    public class RecoilCrosshairTweener : Tweener
    {
        [SerializeField] private Transform _toScale;
        [SerializeField] private Vector3 _targetRecoilValue;
        [SerializeField] private float _duration;
        [SerializeField] private Ease _ease;
        [SerializeField] private Vector3 _targetBackValue;
        [SerializeField] private float _backDuration;
        [SerializeField] private Ease _backEase;
        
        private Tween _tween;
        
        public override void Play()
        {
            Kill();
            _tween = _toScale.DOScale(_targetRecoilValue, _duration).SetEase(_ease).OnComplete(() =>
                _toScale.DOScale(_targetBackValue, _backDuration).SetEase(_backEase).OnComplete(Complete));
        }
        public override void Kill() =>
            _tween?.Kill();   
    }
}