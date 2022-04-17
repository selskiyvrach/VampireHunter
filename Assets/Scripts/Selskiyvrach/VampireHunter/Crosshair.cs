using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;

namespace Selskiyvrach.VampireHunter
{
    public class Crosshair : ICrosshair
    {
        private readonly RectTransform _crosshair;
        private readonly CanvasGroup _crosshairGroup;
        private bool _aimed;
        private bool _idled;
        private TweenerCore<Vector3, Vector3, VectorOptions> _aimingTween;


        public bool Aimed => _aimed;
        public bool Idled => _idled;
        public RectTransform ScreenPos => _crosshair;

        public Crosshair(RectTransform crosshair, CanvasGroup crosshairGroup)
        {
            _crosshair = crosshair;
            _crosshairGroup = crosshairGroup;
        }

        public void TransitionToIdle()
        {
            if (_idled)
                return;
            _aimed = false;
            _idled = false;
            _aimingTween?.Kill();
            _crosshair.DOScale(3f, .1f).OnComplete(OnIdled).SetEase(Ease.OutSine);
        }

        public void TransitionToAimed()
        {
            if(_aimed)
                return;
            _aimed = false;
            _idled = false;
            _aimingTween = _crosshair.DOScale(1, 1f).OnComplete(OnAimed);
        }

        public void TransitionToRecoil()
        {
            _aimed = false;
            _idled = false;
            _crosshair.DOScale(6f, .1f).OnComplete(TransitionFromRecoilToIdle).SetEase(Ease.OutSine);
            _crosshairGroup.DOFade(.25f, .1f).SetEase(Ease.OutSine);
        }

        private void TransitionFromRecoilToIdle()
        {
            _aimed = false;
            _idled = false;
            _crosshair.DOScale(3f, .55f).OnComplete(OnIdled).SetEase(Ease.InSine);
            _crosshairGroup.DOFade(1, .55f).SetEase(Ease.InSine);
        }

        private void OnAimed()
        {
            _aimed = true;
            _idled = false;
        }

        private void OnIdled()
        {
            _idled = true;
            _aimed = false;
        }
    }
}