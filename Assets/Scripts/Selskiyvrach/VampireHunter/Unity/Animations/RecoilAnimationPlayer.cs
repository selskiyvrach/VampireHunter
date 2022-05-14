using DG.Tweening;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Selskiyvrach.VampireHunter.Unity.Animations
{
    public class RecoilAnimationPlayer : MonoBehaviour
    {
        [SerializeField] private Transform _animated;
        [SerializeField] private float _recoilUpDegrees = 45;
        [SerializeField] private float _recoilSidesDegrees = 10;
        [SerializeField] private float _duration = .1f;
        [SerializeField] private float _returnTime = .25f;
        [SerializeField] private Ease _recoilEase = Ease.OutQuint;
        [SerializeField] private Ease _returnEase = Ease.InOutQuint;

        [Button]
        public void PlayRecoil()
        {
            _animated
                .DOLocalRotate(new Vector3(
                    _recoilUpDegrees, 
                    Random.Range(-_recoilSidesDegrees, _recoilSidesDegrees), 
                    0), 
                    _duration)
                .SetEase(_recoilEase)
                .OnComplete(
                    () => _animated.DOLocalRotate(Vector3.zero, _returnTime)).SetEase(_returnEase);
        }
    }
}