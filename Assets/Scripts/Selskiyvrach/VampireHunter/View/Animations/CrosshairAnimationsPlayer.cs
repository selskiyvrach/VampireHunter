using Sirenix.OdinInspector;
using UnityEngine;

namespace Selskiyvrach.VampireHunter.View.Animations
{
    public class CrosshairAnimationsPlayer : MonoBehaviour
    {
        [SerializeField] private Tweener _recoilTweener;
        [SerializeField] private Tweener _idleTweener;
        [SerializeField] private Tweener _aimTweener;
        
        private Tweener _current;
        public ICallback OnRecoilFinished => _recoilTweener; 
        public ICallback OnIdled => _idleTweener; 
        public ICallback OnAimed => _aimTweener;

        [Button]
        public void PlayRecoil()
        {
            KillCurrent();
            _current = _recoilTweener;
            _recoilTweener.Play();
        }

        [Button]
        public void PlayIdle()
        {
            KillCurrent();
            _current = _idleTweener;
            _idleTweener.Play();
        }

        [Button]
        public void PlayAim()
        {
            KillCurrent();
            _current = _aimTweener;
            _aimTweener.Play();
        }

        private void KillCurrent()
        {
            if(_current != null)
                _current.Kill();
        }
    }
}