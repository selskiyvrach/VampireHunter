using DG.Tweening;
using UnityEngine;

namespace Selskiyvrach.VampireHunter.Unity.Animations
{
    public class ScaleTweener : Tweener
    {
        [SerializeField] private Transform _toScale;
        [SerializeField] private Vector3 _targetValue;
        [SerializeField] private float _duration;
        [SerializeField] private Ease _ease;

        private Tween _tween;
        
        public override void Play() =>
            _tween = _toScale.DOScale(_targetValue, _duration).SetEase(_ease).OnComplete(Complete);

        public override void Kill() =>
            _tween?.Kill();
    }
}