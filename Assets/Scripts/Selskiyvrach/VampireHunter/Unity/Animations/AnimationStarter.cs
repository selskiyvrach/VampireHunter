using UnityEngine;

namespace Selskiyvrach.VampireHunter.Unity.Animations
{
    public class AnimationStarter : MonoBehaviour
    {
        [SerializeField] private string _triggerName;
        [SerializeField] private Animator _animator;
        
        private int _triggerHash;

        private void Awake() =>
            _triggerHash = Animator.StringToHash(_triggerName);

        public void StartAnimation() =>
            _animator.SetTrigger(_triggerHash);
    }
}