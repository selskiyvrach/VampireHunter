using DG.Tweening;
using UnityEngine;

namespace Selskiyvrach.VampireHunter
{
    public class RecoilAnimationPlayer : MonoBehaviour
    {
        [SerializeField]
        private float _rotationX;

        [SerializeField] 
        private float _minRotationY;
        
        [SerializeField] 
        private float _maxRotationY;
        
        [SerializeField] 
        private Vector3 _displacement;

        [SerializeField]
        private float _duration;
        
        [SerializeField]
        private Transform _animatedItem;

        [SerializeField] 
        private AnimationCurve _recoilToIdleCurve;
        
        public void PlayRecoilAnimation()
        {
            var rotationY = Random.Range(_minRotationY, _maxRotationY);
            _animatedItem.DOLocalRotate(new Vector3(_rotationX, rotationY, 0), _duration).OnComplete(MoveToIdlePosition).SetEase(Ease.OutSine);
            _animatedItem.DOLocalMove(_displacement, _duration).SetEase(Ease.OutSine);
        }

        private void MoveToIdlePosition()
        {
            _animatedItem.DOLocalRotate(Vector3.zero, 1f).SetEase(_recoilToIdleCurve);
            _animatedItem.DOLocalMove(Vector3.zero, .45f).SetEase(Ease.OutSine);
        }
    }
}