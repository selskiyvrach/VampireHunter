using DG.Tweening;
using UnityEngine;

namespace Selskiyvrach.VampireHunter
{
    public class GunAnimationsPlayer : MonoBehaviour
    {
        [SerializeField]
        private Transform _gunHolder;

        [SerializeField] 
        private AnimationCurve _recoilToIdleCurve;
        
        private bool _centered;

        public bool Centered => _centered;

        public void PlayRecoilAnimation()
        {
            _gunHolder.DOLocalRotate(new Vector3(0, 50, 0), .1f).OnComplete(MoveToIdlePosition).SetEase(Ease.OutSine);
            _gunHolder.DOLocalMove(new Vector3(0.02f, 0, 0.01f), .1f).SetEase(Ease.OutSine);
            _centered = false;
        }

        private void MoveToIdlePosition()
        {
            _gunHolder.DOLocalRotate(new Vector3(0, 0, 0), 1f).OnComplete(OnCentered).SetEase(_recoilToIdleCurve);
            _gunHolder.DOLocalMove(new Vector3(0, 0, 0), .45f).SetEase(Ease.OutSine);
        }

        private void OnCentered()
        {
            _centered = true;
        }
    }
}