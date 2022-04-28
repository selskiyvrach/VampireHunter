using System;
using UnityEngine;

namespace Selskiyvrach.VampireHunter.Unity
{
    public class AnimationPlayer : MonoBehaviour
    {
        [SerializeField] private string _triggerName;
        [SerializeField] private string _callBackKey;
        [SerializeField] private Animator _animator;
        
        private int _triggerHash;
        private Action _callback;

        private void Awake()
        {
            _triggerHash = Animator.StringToHash(_triggerName);
        }

        public void Play(Action callback)
        {
            _callback = callback;
            _animator.SetTrigger(_triggerHash);
        }

        public void OnAnimationCallback()
        {
            _callback.Invoke();
        }
    }
}